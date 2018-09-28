using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleExcel.Models
{
    public class FileType
    {
        public string EduLevel { get; set; }
        public string EduForm { get; set; }
        public string Type { get; set; }
    }

    public static class FileTypeExtension
    {
        public static FileType ToFileType(this string fileName)
        {
            string[] items = fileName.Split('_');
            if(items.Count() > 2)
            {
                return new FileType()
                {
                    EduForm = items[0],
                    EduLevel = items[1],
                    Type = items[2]
                };
            }
            throw new NullReferenceException();
            
        }
    }
}
