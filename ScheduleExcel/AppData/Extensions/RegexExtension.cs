using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScheduleExcel.AppData
{
    public static class RegexExtension
    {
        public static bool IsGroupName(this string text)
        {
            Regex regex = new Regex(@"^[0-9][0-9][А-Яа-я]*[\d]*[а-я]*");
            return regex.IsMatch(text);
        }

        public static bool IsText(this string text)
        {
            Regex regex = new Regex(@"^[А-Яа-я]*");
            return regex.IsMatch(text);
        }

        public static bool IsTime(this string text)
        {
            Regex regex = new Regex(@"[\d]*:[\d]*");
            return regex.IsMatch(text);
        }
    }
}
