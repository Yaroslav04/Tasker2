using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class NotificationDataBase : CUDDataBase<NotificationClass>
    {
        public NotificationDataBase(string _connectionString)
        {
            connection = new SQLiteAsyncConnection(_connectionString);
            connection.CreateTableAsync<NotificationClass>().Wait();
        }
    }
}
