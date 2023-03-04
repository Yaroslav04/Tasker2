using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class ObjectDataBase : CUDDataBase<ObjectClass>
    {
        public ObjectDataBase(string _connectionString)
        {
            connection = new SQLiteAsyncConnection(_connectionString);
            connection.CreateTableAsync<ObjectClass>().Wait();
        }

        public async Task<bool> IsObjectExistAsync(int _taskId, int _periodId, DateTime _date)
        {
            var s = await connection.Table<ObjectClass>()
            .Where(x => x.TaskId == _taskId & x.PeriodId == _periodId
            & x.Date == _date).ToListAsync();

            if (s.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ObjectClass> GetObjectAsync(int _taskId, int _periodId, DateTime _date)
        {
            return await connection.Table<ObjectClass>()
                .Where(x => x.TaskId == _taskId & x.PeriodId == _periodId
                & x.Date == _date).FirstOrDefaultAsync();
        }
    }
}
