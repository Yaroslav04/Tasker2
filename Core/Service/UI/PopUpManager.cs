using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.UI
{
    public static class PopUpManager
    {
        public static async Task<PeriodClass> CreateNewPeriod(string _taskName)
        {
            PeriodClass periodClass = new PeriodClass();
            string title = $"Додати період для {_taskName}";

            periodClass.Priority = await PopUpTemplate.GetElementNotNull(title, "Пріоритет", EnumManager.EPeriodPriority);
            periodClass.StartDate = Convert.ToDateTime(await PopUpTemplate.GetDate(title, "Дата початку", DateTime.Now.ToShortDateString()));
            periodClass.EndDate = Convert.ToDateTime(await PopUpTemplate.GetDate(title, "Дата закінчення", DateTime.Now.ToShortDateString()));
            periodClass.ControlDate = Convert.ToDateTime(await PopUpTemplate.GetDate(title, "Контрольна дата", periodClass.EndDate.ToShortDateString()));
            periodClass.Period = await PopUpTemplate.GetElementNotNull(title, "Період", EnumManager.EPeriodPeriod);
            periodClass.IsPeriodExecute = await PopUpTemplate.BoolMessage(title, "Автовиконання після закінчення часу виконання");
            periodClass.IsWorkingDayAdjustment = await PopUpTemplate.BoolMessage(title, "Перенесення до буднього дня");
            periodClass.IsNotify = await PopUpTemplate.BoolMessage(title, "Відправляти сповіщення");
            if (periodClass.IsNotify)
            {
                periodClass.StartTime = Convert.ToDateTime(await PopUpTemplate.GetTime(title, "Час початку сповіщення", DateTime.Now.ToShortTimeString())).TimeOfDay;
                periodClass.StopTime = Convert.ToDateTime(await PopUpTemplate.GetTime(title, "Час закінчення сповіщення", DateTime.Now.ToShortTimeString())).TimeOfDay;
                periodClass.Pause = Convert.ToInt32(await PopUpTemplate.GetNumber(title, "Пауза між повідолменнями"));
            }
            else
            {
                periodClass.StartTime = TimeSpan.Zero;
                periodClass.StopTime = TimeSpan.Zero;
                periodClass.Pause = 0;
            }

            periodClass.Status = EnumManager.EPeriodStatus[0];
            return periodClass;
        }
    }
}
