using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.Engine
{
    public class EngineAgrerator
    {
        public static async Task Run(TaskClass task, List<PeriodClass> periods)
        {
            //!!!!!var periods = await App.DataBase.PeriodDB.GetListAsync(task.N);

            foreach (var period in periods)
            {
                //проверка статуса периода
                if (period.Status == EnumManager.EPeriodStatus[0])
                {
                    ////получаем период дней для обьектов
                    DateTime endDate = period.EndDate;

                    if ((period.EndDate - DateTime.Now).TotalDays > 366)
                    {
                        endDate = DateTime.Now.AddDays(366);
                    }

                    //перебирем все дни периода
                    foreach (DateTime day in EachDay(period.StartDate, period.EndDate))
                    {
                            if (PeriodParser.IsPeriod(period, day))
                            {
                                Debug.WriteLine($"День: {day}");
                                Debug.WriteLine("true");
                            }                                      
                    }                      
                }
            }
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
