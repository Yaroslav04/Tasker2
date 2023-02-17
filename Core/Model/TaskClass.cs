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
        public string Section { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
