using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Model
{
    public class PeriodClass : TemplateClass
    {
        [Indexed(Name = "ListingID", Order = 1, Unique = true)]
        public int TaskId { get; set; }
        public string Priority { get; set; }
        //високий пріоритет, звичайний пріоритет
        [Indexed(Name = "ListingID", Order = 2, Unique = true)]
        public DateTime StartDate { get; set; }
        //дата початку виконання пероіду, за замовчуванням дата збереження
        [Indexed(Name = "ListingID", Order = 3, Unique = true)]
        public DateTime EndDate { get; set; }
        //дата закінчення пероіду (якщо DateTime == max без закінчення), день початку за замовчуванням
        [Indexed(Name = "ListingID", Order = 4, Unique = true)]
        public DateTime ControlDate { get; set; }
        //за замовчуваням EndDate, якщо max то без закінчення
        [Indexed(Name = "ListingID", Order = 5, Unique = true)]
        public string Period { get; set; }
        //пероідичність виконання
        public bool IsPeriodExecute { get; set; }
        //якщо true то після закінчення часу виконання ставиться статус не виконано
        public bool IsWorkingDayAdjustment { get; set; }
        //якщо true то контрольна дата корегується до вихідних до попереднього робочого дня
        public bool IsNotify { get; set; }
        //якщо true то виконання виводиться у сповіщення
        public TimeSpan NotificationTime { get; set; }
        //час початку виконання, якщо min то з почтку дня виконання
        public string Status { get; set; }
        //активний, не активний






    }
}
