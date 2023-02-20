using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Model
{
    public class NotificationClass : TemplateClass
    {
        [Indexed(Name = "ListingID", Order = 1, Unique = true)]
        public string Type { get; set; }

        [Indexed(Name = "ListingID", Order = 2, Unique = true)]
        public string Description { get; set; }
        public bool IsShow { get; set; }
    }
}
