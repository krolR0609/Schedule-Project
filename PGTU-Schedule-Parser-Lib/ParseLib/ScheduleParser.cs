using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseLib
{
    public static class ScheduleParser
    {
        public static List<KeyValuePair<string, string>> Parse(string inputString)
        {
            string[] resultArray = inputString.Split('\n');
            List<KeyValuePair<string, string>> resultList = new List<KeyValuePair<string, string>>();

            foreach (var text in resultArray)
            {
                resultList.Add(Match(text));
            }
            return resultList;
        }

        private static KeyValuePair<string, string> Match(string text)
        {
            if (text.IsWeek())
            {
                return new KeyValuePair<string, string>("week", text);
            }
            if (text.IsTime())
            {
                return new KeyValuePair<string, string>("time", text);
            }
            if (text.IsTeacher())
            {
                return new KeyValuePair<string, string>("teacher", text);
            }
            if (text.IsPlace())
            {
                return new KeyValuePair<string, string>("place", text);
            }
            if (!String.IsNullOrEmpty(text) && !String.IsNullOrWhiteSpace(text))
            {
                return new KeyValuePair<string, string>("discipline", text);
            }
            return new KeyValuePair<string, string>("error", text);
        }
    }

    public static class RegexExtenstion
    {
        public static bool IsTime(this string text)
        {
            Regex regex = new Regex(@"^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])(:[0-5][0-9])?");
            return regex.IsMatch(text);
        }

        public static bool IsPlace(this string text)
        {
            Regex regex = new Regex(@"^([а-я]*\Dа.*([а-яА-Я]*))");
            return regex.IsMatch(text);
        }
        public static bool IsTeacher(this string text)
        {
            Regex normal = new Regex(@"^([А-я]* [А-Я].[А-Я].)");
            Regex group = new Regex(@"^([А-я]\D*-){1,3}");

            return normal.IsMatch(text) || group.IsMatch(text) ;
        }
        public static bool IsWeek(this string text)
        {
            Regex regex = new Regex(@"^(по\D\d\D\S*)");
            return regex.IsMatch(text);
        }

        
    }
}
