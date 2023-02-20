using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class SubTypeDataBase : CUDDataBase<SubTypeClass>
    {
        public SubTypeDataBase(string _connectionString)
        {
            connection = new SQLiteAsyncConnection(_connectionString);
            connection.CreateTableAsync<SubTypeClass>().Wait();
        }
    }
}
