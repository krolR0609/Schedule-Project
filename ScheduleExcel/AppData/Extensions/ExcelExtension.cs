using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ScheduleExcel.Models.Enums;

namespace ScheduleExcel.AppData
{
    public static class ExcelExtension
    {
        public static string GetValue(this ExcelRange range)
        {
            return range.Value?.ToString();
        }
        public static string GetValue(this ExcelRangeBase range)
        {
            return range.Value?.ToString();
        }
        public static int StartRow(this ExcelRange range)
        {
            return range.Start.Row;
        }
        public static int StartColumn(this ExcelRange range)
        {
            return range.Start.Column;
        }

        public static int FindGroupRow(this ExcelWorksheet worksheet, int startRow, int column)
        {
            for (int i = startRow + 1; i >= 1; i--)
            {
                if (worksheet.Cells[i, column].Value != null)
                {
                    if (worksheet.Cells[i, column].GetValue().IsGroupName())
                    {
                        return worksheet.Cells[i, column].StartRow();
                    }
                }
            }
            throw new Exception();
        }

        public static int FindStartRow(this ExcelWorksheet worksheet)
        {
            for (var i = 2; i < worksheet.Dimension.Rows; i++)
            {
                if (worksheet.Cells[i, 1].Value != null)
                {
                    return worksheet.Cells[i, 1].StartRow();
                }
            }
            return 2;
        }

        public static ScheduleType FindSheetType(this ExcelWorksheet worksheet)
        {
            for (int i = 2; i < worksheet.Dimension.End.Row; i++)
            {
                if (worksheet.Cells[i, 2].Value != null)
                {
                    if (worksheet.Cells[i, 2].GetValue().IsTime())
                    {
                        return ScheduleType.Normal;
                    }
                    if (worksheet.Cells[i, 2].GetValue().IsText())
                    {
                        return ScheduleType.Evening;
                    }
                    
                }
            }
            throw new NotImplementedException();
        }
    }
}
