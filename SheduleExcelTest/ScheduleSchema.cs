using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PenzGTUSchedule_schema.Schema.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheduleExcelTest
{
    [TestClass]
    public class ScheduleSchema
    {

        [TestMethod]
        public void TestJsonSerializeObject()
        {
            RootItem testedItem = GetTestItem();
            string json = JsonConvert.SerializeObject(testedItem);
            string expected = @"{'id':1,'day':'Friday','time':'15:00','subjects':[{'id':1,'week':1,'lesson':{'id':1,'name':'СИО МП'},'teacher':{'id':1,'name':'Волков В.В.'},'place':'лекция а.5-402'},{'id':2,'week':2,'lesson':{'id':2,'name':'Тех.обеспечение КИМ'},'teacher':{'id':1,'name':'Волков В.В.'},'place':'пр.а.5-404'}]}";
            expected = expected.Replace("'", "\"");
            Assert.AreEqual(expected, json);
        }

        [TestMethod]
        public void TestJsonDesirializeObject()
        {
            string json = @"{'id':1,'day':'Friday','time':'15:00','subjects':[{'id':1,'week':1,'lesson':{'id':1,'name':'СИО МП'},'teacher':{'id':1,'name':'Волков В.В.'},'place':'лекция а.5-402'},{'id':2,'week':2,'lesson':{'id':2,'name':'Тех.обеспечение КИМ'},'teacher':{'id':1,'name':'Волков В.В.'},'place':'пр.а.5-404'}]}";
            RootItem scheduleItem = JsonConvert.DeserializeObject<RootItem>(json);
            RootItem expected = GetTestItem();
            Assert.AreEqual(expected.Time, scheduleItem.Time);
            Assert.AreEqual(expected.Subjects.First().Place, scheduleItem.Subjects.First().Place);
        }
        private RootItem GetTestItem()
        {
            /*
             * по 1 неделе
            СИО МП
            лекция а.5-402
            Волков В.В.
             */
            Subject firstSubject = new Subject()
            {
                Id = 1,
                Week = 1,
                Place = "лекция а.5-402",
                Lesson = new Lesson()
                {
                    Id = 1,
                    Name = "СИО МП"
                },
                Teacher = new Teacher()
                {
                    Id = 1,
                    Name = "Волков В.В."
                }
            };
            /*
            по 2 неделе
            Тех.обеспечение КИМ
            пр.а.5-404
            Волков В.В.
             */
            Subject secondSubject = new Subject()
            {
                Id = 2,
                Week = 2,
                Place = "пр.а.5-404",
                Lesson = new Lesson()
                {
                    Id = 2,
                    Name = "Тех.обеспечение КИМ"
                },
                Teacher = new Teacher()
                {
                    Id = 1,
                    Name = "Волков В.В."
                }
            };
            RootItem rootItem = new RootItem()
            {
                Id = 1,
                Day = System.DayOfWeek.Friday,
                Time = new DateTime(2018, 9, 28, 15, 0, 0, 0),
                Subjects = new List<Subject>()
                {
                    firstSubject, secondSubject
                }
            };
            return rootItem;
        }
    }
}
