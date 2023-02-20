using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Model
{
    public class PeriodClass : TemplateClass
    {
        public string TaskId { get; set; }
        public string Priority { get; set; }
        //високий пріоритет, звичайний пріоритет
        public DateTime StartDate { get; set; }
        //дата початку виконання пероіду, за замовчуванням дата збереження
        public DateTime EndDate { get; set; }
        //дата закінчення пероіду (якщо DateTime == max без закінчення)
        public DateTime ControlDate { get; set; }
        //за замовчуваням EndDate, якщо max то без закінчення
        public string Period { get; set; }
        //пероідичність виконання
        public TimeSpan StartTime { get; set; }
        //час початку виконання, якщо min то з почтку дня виконання
        public TimeSpan StopTime { get; set; }
        //час закінчення виконання, якщо max то до кінця дня, для роботи до 18:00 за замовчуванням
        public int Pause { get; set; }
        //пауза виконання
        public bool IsPeriodExecute { get; set; }
        //якщо true то після закінчення часу виконання ставиться статус не виконано
        public bool IsWorkingDayAdjustment { get; set; }
        //якщо true то контрольна дата корегується до вихідних до попереднього робочого дня
        public bool IsNotify { get; set; }
        //якщо true то виконання виводиться у сповіщення
        public string Status { get; set; }
        //активний, не активний






    }
}
