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
    }
}
