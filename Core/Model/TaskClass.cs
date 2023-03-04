using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Model
{
    public class TaskClass : TemplateClass
    {
        [Indexed(Name = "ListingID", Order = 1, Unique = true)]
        public string Section { get; set; }
        [Indexed(Name = "ListingID", Order = 2, Unique = true)]
        public string Type { get; set; }
        [Indexed(Name = "ListingID", Order = 3, Unique = true)]
        public string SubType { get; set; }
        [Indexed(Name = "ListingID", Order = 4, Unique = true)]
        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
