using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ScheduleExcel.Models;
using ScheduleExcel.Models.Interfaces;
using static ScheduleExcel.Models.Enums;

namespace ScheduleExcel.AppData.PengzGTU
{
    public class ScheduleParser<T> : AbstractParser<T> where T : IScheduleItem
    {

        private List<T> Items = new List<T>();
        private string _currentDay = "";

        private readonly int _currentStartRow = 2;
        private readonly int _currentStartColumn = 3;
        private readonly int _currentGroupRow = 1; 

        public ScheduleParser(IParserSettings settings) : base(settings)
        {
        }

        public override List<T> Parse()
        {
            OnStart?.Invoke(this, EventArgs.Empty);

            if(settings == null)
            {
                throw new NullReferenceException("Settings is not defined");
            }
            FileInfo[] filesPath = GetFilesPath();
            foreach (var filePath in filesPath)
            {
                ProceedExcelBook(filePath.FullName);
            }

            OnFinish?.Invoke(this, Items);
            return Items;
        }

        private void ProceedExcelBook(string path)
        {
            using (var excelPackage = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    excelPackage.Load(stream);
                    foreach (var worksheet in excelPackage.Workbook.Worksheets)
                    {
                        ProceedExcelWorksheet(worksheet);
                    }
                }
            }
        }

        private void ProceedExcelWorksheet(ExcelWorksheet worksheet)
        {
            ScheduleType worksheetType = worksheet.FindSheetType();
            foreach (var currentCell in worksheet.Cells[_currentStartRow, _currentStartColumn, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column])
            {
                if (currentCell.Value != null)
                {
                    var currentScheduleItem = CreateScheduleItem(worksheetType, currentCell);
                    Items.Add(currentScheduleItem);
                    OnItemProceed?.Invoke(this, currentScheduleItem);
                }
            }
        }

        public T CreateScheduleItem(ScheduleType type, ExcelRangeBase cell)
        {
            if (type == ScheduleType.Normal)
            {
                return GetScheduleItem(cell);
            }
            if (type == ScheduleType.Evening)
            {
                return GetEveningScheduleItem(cell);
            }
            
            throw new Exception("Для данного типа листа нет реализации");
        }
        private T GetScheduleItem(ExcelRangeBase cell)
        {
            var _currentWorksheet = cell.Worksheet;

            if (_currentWorksheet.Cells[cell.Start.Row, 1].Value != null)
            {
                _currentDay = _currentWorksheet.Cells[cell.Start.Row, 1].GetValue();
            }
            string Time = DateTime.Parse(_currentWorksheet.Cells[cell.Start.Row, 2].GetValue()).ToShortTimeString();
            string Value = cell.GetValue();
            string Group = _currentWorksheet.Cells[_currentGroupRow, cell.Start.Column].GetValue().ToGroup();
            string Day = _currentDay;
            return (T) new ScheduleItem().Create(Time, Value, Group, Day);
        }
        private T GetEveningScheduleItem(ExcelRangeBase cell)
        {
            var _currentWorksheet = cell.Worksheet;
            if (_currentWorksheet.Cells[cell.Start.Row, 1].Value != null)
            {
                _currentDay = _currentWorksheet.Cells[cell.Start.Row, 1].GetValue();
            }

            string[] itemsArray = cell.GetValue().Split('\n');
            string Time = itemsArray[0];
            string Value = String.Join(" ", itemsArray.Skip(1));
            string Group = _currentWorksheet.Cells[1, cell.Start.Column].GetValue().ToGroup();
            string Day = _currentDay;
            return (T) new ScheduleItem().Create(Time, Value, Group, Day);
        }

        private FileInfo[] GetFilesPath()
        {
            DirectoryInfo directoryInfo;
            if (String.IsNullOrEmpty(settings.CurrentPath))
            {
                throw new DirectoryNotFoundException();
            }
            else
            {
                directoryInfo = new DirectoryInfo(settings.CurrentPath);
            }
             
            return directoryInfo.GetFiles(settings.FilePattern).ToArray();
        }
    }
}
