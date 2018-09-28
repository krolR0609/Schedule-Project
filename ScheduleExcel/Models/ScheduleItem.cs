using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleExcel.AppData;
using OfficeOpenXml;

namespace ScheduleExcel.Models
{
    public class ScheduleItem : IScheduleItem
    {
        public string Day { get; set; }
        public string Group { get; set; }
        public string Value { get; set; }
        public string Time { get; set; }

        public IScheduleItem Create(string time, string value, string group, string day)
        {
            return new ScheduleItem()
            {
                Time = time,
                Day = day,
                Value = value,
                Group = group
            };
        }
    }
}
