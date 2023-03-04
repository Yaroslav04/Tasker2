using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.Engine
{
    public class EngineAgrerator
    {

        public static async Task RunTasks()
        {
            foreach (var task in await App.DataBase.TaskDB.GetListAsync(EnumManager.ETaskStatus[0]))
            {
                await RunPeriodsFromTask(task);
            }
        }

        static async Task RunPeriodsFromTask(TaskClass task)
        {

            foreach (var period in await App.DataBase.PeriodDB.GetListAsync(task.N))
            {
                if (period.Status == EnumManager.EPeriodStatus[0])
                {

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
                            //если не существует создаем обьект
                            if (!await App.DataBase.ObjectDB.IsObjectExistAsync(task.N, period.N, day))
                            {
                                try
                                {
                                    await App.DataBase.ObjectDB.Save(new ObjectClass
                                    {
                                        TaskId = task.N,
                                        PeriodId = period.N,
                                        Date = day,
                                        Status = EnumManager.EObjectStatus[0]
                                    });
                                }
                                catch
                                {

                                }
                            }

                            //если существует
                            if (await App.DataBase.ObjectDB.IsObjectExistAsync(task.N, period.N, day))
                            {
                                var obj = await App.DataBase.ObjectDB.GetObjectAsync(task.N, period.N, day);
                                //если статус на викоанні
                                if (obj.Status == EnumManager.EObjectStatus[0])
                                {
                                    //если дата обьекта меньше сегодяшнего дня
                                    if (obj.Date < DateTime.Now.Date)
                                    {
                                        if (period.IsPeriodExecute)
                                        {
                                            obj.Status = EnumManager.EObjectStatus[2];
                                            await App.DataBase.ObjectDB.Update(obj);
                                        }
                                    }
                                }
                            }

                            //Если обьект существует и время больше чем время уведомления  => добавляем в оповещение (там обьект делаеться один раз и падает в уведомление)

                        }
                    }
                }
            }
        }

        static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
