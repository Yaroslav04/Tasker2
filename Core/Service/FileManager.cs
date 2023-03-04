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
            if (Directory.Exists(@"/storage/emulated/0/Tasker2/"))
            {
                return @"/storage/emulated/0/Tasker2/";
            }

            if (Directory.Exists(@"Q:\"))
            {
                return @"Q:\";
            }

            throw new ArgumentException("File system not exist");     
        }

        public static string Path(string _file)
        {
            return System.IO.Path.Combine(Path(), _file);
        }
    }
}
