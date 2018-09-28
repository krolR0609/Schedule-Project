using ScheduleExcel.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleExcel.AppData.PengzGTU
{
    public class ScheduleParserSettings : IParserSettings
    {
        public ScheduleParserSettings()
        {

        }
        public string FilePattern { get; set; }
        public string CurrentPath { get; set; }
    }
}
