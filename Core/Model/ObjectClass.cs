using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Model
{
    public class ObjectClass : TemplateClass
    {
        [Indexed(Name = "ListingID", Order = 1, Unique = true)]
        public int TaskId { get; set; }
        [Indexed(Name = "ListingID", Order = 2, Unique = true)]
        public int PeriodId { get; set; }
        [Indexed(Name = "ListingID", Order = 3, Unique = true)]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
