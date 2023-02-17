using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Model
{
    public class ObjectClass : TemplateClass
    {
        public string TaskId { get; set; }
        public string PeriodId { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        //за замовчуванням дата створення
        public string Status { get; set; }
    }
}
