using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleExcel.AppData;
using ScheduleExcel.AppData.PengzGTU;
using ScheduleExcel.Models;
using ScheduleExcel.Models.Interfaces;

namespace SheduleExcelTest
{
    [TestClass]
    public class MainTests
    {
        string _directory = "EXCEL";
        string _filePattern = "*_tt.xls*";
        string _currentPath = @"C:\Users\N.artyushkin\source\repos\ScheduleExcel\SheduleExcelTest\TestXLS\";


        [TestMethod]
        public void TestIternalNoPath()
        {
            IParserSettings scheduleParserSettings = new ScheduleParserSettings()
            {
                FilePattern = "*_tt.xls*",
                CurrentPath = @"C:\Users\N.artyushkin\source\repos\ScheduleExcel\ScheduleExcel\bin\Debug\EXCEL\"

            };
            AbstractParser<ScheduleItem> parser = new ScheduleParser<ScheduleItem>(scheduleParserSettings);
            Assert.ThrowsException<DirectoryNotFoundException>(parser.Parse);
        }

        [TestMethod]
        public void TestIternal()
        {
            IParserSettings scheduleParserSettings = new ScheduleParserSettings()
            {
                FilePattern = "*_tt.xlsx",
                CurrentPath = @"C:\Users\N.artyushkin\source\repos\ScheduleExcel\ScheduleExcel\bin\Debug\EXCEL\"
            };
            AbstractParser<ScheduleItem> parser = new ScheduleParser<ScheduleItem>(scheduleParserSettings);
            List<ScheduleItem> parsedItems =  parser.Parse();
            Assert.AreEqual(2255, parsedItems.Count);
            foreach(var item in parsedItems)
            {
                Assert.AreEqual(true, !String.IsNullOrEmpty(item.Group));
            }
        }
    }
}
