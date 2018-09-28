using ScheduleExcel.AppData;
using ScheduleExcel.AppData.PengzGTU;
using ScheduleExcel.Models;
using ScheduleExcel.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleExcel
{
    class Program
    {
        static void Main(string[] args)
        {

            IParserSettings scheduleParserSettings = new ScheduleParserSettings()
            {
                FilePattern = "*_tt.xlsx",
                CurrentPath = @"C:\Users\N.artyushkin\source\repos\ScheduleExcel\ScheduleExcel\bin\Debug\EXCEL\"
            };

            AbstractParser<ScheduleItem> parser = new ScheduleParser<ScheduleItem>(scheduleParserSettings);
            parser.OnItemProceed += (o, i) =>
            {
                if (i.Group.Contains("17ИЭ1м"))
                {
                    Console.WriteLine($"{i.Day} {i.Time} {i.Value} {i.Group}");
                }
                
            };
            Console.ReadKey();
        }

    }
}
