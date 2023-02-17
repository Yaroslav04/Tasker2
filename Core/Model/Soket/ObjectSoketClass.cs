using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Model.Soket
{
    public class ObjectSoketClass : ObjectClass
    {
        public TaskClass TaskSoket { get; set; }
        public PeriodClass PeriodSoket { get; set; }
        public ObjectSoketClass(ObjectClass obj, TaskClass task, PeriodClass period)
        {
            this.N = obj.N;
            this.SaveDate = obj.SaveDate;

            this.TaskId = obj.TaskId;
            this.PeriodId = obj.PeriodId;
            this.Description = obj.Description;
            this.CreateDate = obj.CreateDate;
            this.Status= obj.Status;

            TaskSoket = task;
            PeriodSoket = period;
        }
    }
}
