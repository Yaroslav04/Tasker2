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
            await Task.Delay(5000);
            var _task = await PopUpManager.CreateNewTask();
            await App.DataBase.TaskDB.Save(_task);
            var task = await App.DataBase.TaskDB.GetTaskFromTask(_task);

            var _period = await PopUpManager.CreateNewPeriod(task.Name, task.N);
            await App.DataBase.PeriodDB.Save(_period);
            var period  = App.DataBase.PeriodDB.GetPeriodFromPeriod(_period);

            await EngineAgrerator.RunTasks();
        }
    }
}
