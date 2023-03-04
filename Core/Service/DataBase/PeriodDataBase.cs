using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class PeriodDataBase : CUDDataBase<PeriodClass>
    {
        public PeriodDataBase(string _connectionString)
        {
            connection = new SQLiteAsyncConnection(_connectionString);
            connection.CreateTableAsync<PeriodClass>().Wait();
        }

        public async Task<List<PeriodClass>> GetListAsync()
        {
            try
            {
                return await connection.Table<PeriodClass>().ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<PeriodClass>> GetListAsync(int _id)
        {
            try
            {
                return await connection.Table<PeriodClass>().Where(x => x.TaskId == _id).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<PeriodClass> GetPeriodFromPeriod(PeriodClass _period)
        {
            return await connection.Table<PeriodClass>()
                .Where(x => x.TaskId == _period.TaskId & x.StartDate == _period.StartDate
                & x.EndDate == _period.EndDate & x.ControlDate == _period.ControlDate 
                & x.Period == _period.Period).FirstOrDefaultAsync();
        }

    }
}
