using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tasker2.Core.Service.DataBase
{
    public class TaskDataBase : CUDDataBase<TaskClass>
    {
        public TaskDataBase(string _connectionString)
        {
            connection = new SQLiteAsyncConnection(_connectionString);
            connection.CreateTableAsync<TaskClass>().Wait();
        }

        public async Task<List<TaskClass>> GetListAsync()
        {
            try
            {
                return await connection.Table<TaskClass>().ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<TaskClass>> GetListAsync(string _status)
        {
            try
            {
                return await connection.Table<TaskClass>().Where(x => x.Status == _status).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<TaskClass> GetTaskFromTask(TaskClass _task)
        {
            return await connection.Table<TaskClass>()
                .Where(x => x.Section == _task.Section & x.Type == _task.Type
                & x.SubType == _task.SubType & x.Name == _task.Name).FirstOrDefaultAsync();
        }
    }
}
