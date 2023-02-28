using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker2.Core.Service.Engine;
using Tasker2.Core.Service.UI;

namespace Tasker2.Core.ViewModel
{
    public class TestViewModel : BaseViewModel
    {
        public TestViewModel()
        { 
            Run();
        }

        public async Task Run()
        {
            await Task.Delay(2000);
            //var period = await PopUpManager.CreateNewPeriod("тест");
            PeriodClass period = new PeriodClass();
            period.StartDate = Convert.ToDateTime("30.01.2023");
            period.EndDate = Convert.ToDateTime("27.10.2024");
            period.ControlDate = Convert.ToDateTime("27.10.2024");
            period.IsWorkingDayAdjustment = true;
            period.Status = EnumManager.EPeriodStatus[0];
            period.Period = EnumManager.EPeriodPeriod[6];
            List<PeriodClass> periods = new List<PeriodClass>();        
            periods.Add(period);
            await EngineAgrerator.Run(new TaskClass(), periods);
        }
    }
}
