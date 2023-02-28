using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Tasker2.Core.Service
{
    public static class TextManager
    {
        public static bool IsDateValid(string _text)
        {
            Regex regex = new Regex(@"^\d\d(.)\d\d(.)\d\d\d\d$");
            return regex.IsMatch(_text);
        }

        public static bool IsTimeValid(string _text)
        {
            Regex regex = new Regex(@"^\d\d(:)\d\d$");
            return regex.IsMatch(_text);
        }

        public static bool IsNumberValid(string _text)
        {
            Regex regex = new Regex(@"\d+");
            return regex.IsMatch(_text);
        }
    }
}
