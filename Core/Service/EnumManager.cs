using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service
{
    public static class EnumManager
    {


        #region Task

        public static List<string> ETaskSection = new List<string>
        {
            "робота",
            "особисте",
        };

        public static List<string> ETaskStatus = new List<string>
        {
            "активний",
            "не активний"
        };

        #endregion

        #region Period

        public static List<string> EPeriodPriority = new List<string>
        {
            "високий",
            "звичайний"
        };

        public static List<string> EPeriodPeriod = new List<string>
        {
            "одноразово",
            "кожен день",
            "кожен будній день",
            "вихідні дні",
            "день тижня",
            "день місяця",
            "день у році",
        };

        public static List<string> EPeriodStatus = new List<string>
        {
            "активний",
            "не активний",
        };

        #endregion

        #region Task

        public static List<string> ENotificationPriority = new List<string>
        {
            "високий",
            "звичайний"
        };

        #endregion


    }
}
