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
            /*0*/"одноразово",
            /*1*/"кожен день",
            /*2*/"кожен будній день",
            /*3*/"вихідні дні",
            /*4*/"день тижня",
            /*5*/"день місяця",
            /*6*/"день в квартал",
            /*7*/"день в рік",
        };

        public static List<string> EPeriodStatus = new List<string>
        {
            "активний",
            "не активний",
        };

        #endregion

        #region Object

        public static List<string> EObjectStatus = new List<string>
        {
            "на виконанні",
            "виконано",
            "пропущено"
        };

        #endregion

        #region Notification

        public static List<string> ENotificationPriority = new List<string>
        {
            "високий",
            "звичайний"
        };

        #endregion


    }
}
