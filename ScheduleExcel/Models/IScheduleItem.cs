using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleExcel.Models
{
    public interface IScheduleItem
    {
        string Time { get; set; }
        string Value { get; set; }
        string Group { get; set; }
        string Day { get; set; }

        IScheduleItem Create(string time, string value, string group, string day);
    }
}
