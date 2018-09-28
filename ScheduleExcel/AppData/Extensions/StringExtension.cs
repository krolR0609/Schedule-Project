using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleExcel.AppData
{
    public static class StringExtension
    {
        public static string ToGroup(this string groupValue)
        {
            return groupValue.Split('\n').First();
        }

        public static string ParseTime(this string time)
        {
            return time.Split('\n').First();
        }
    }
}
