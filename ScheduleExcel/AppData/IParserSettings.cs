using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleExcel.Models.Interfaces
{
    public interface IParserSettings
    {
        string CurrentPath { get; set; }
        string FilePattern { get; set; }
    }
}
