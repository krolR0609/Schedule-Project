using ScheduleExcel.Models;
using ScheduleExcel.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleExcel.AppData
{
    public abstract class AbstractParser<T>
    {
        public EventHandler OnStart;
        public EventHandler<List<T>> OnFinish;
        public EventHandler<T> OnItemProceed;

        protected IParserSettings settings;
        public AbstractParser(IParserSettings settings)
        {
            this.settings = settings;
        }

        public abstract List<T> Parse();

    }
}
