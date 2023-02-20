using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service
{
    public static class FileManager
    {
        public static string Path()
        {
            return @"/storage/emulated/0/Tasker2/"; ;
        }

        public static string Path(string _file)
        {
            return System.IO.Path.Combine(Path(), _file);
        }
    }
}
