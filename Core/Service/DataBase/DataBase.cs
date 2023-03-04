using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class DataBase
    {
        public TaskDataBase TaskDB;
        public PeriodDataBase PeriodDB;
        public ObjectDataBase ObjectDB;
        public TypeDataBase TypeDB;
        public SubTypeDataBase SubTypeDB;
        public NotificationDataBase NotificationDB;

        public DataBase(string _connectionString, List<string> _dataBaseName)
        {
            TaskDB = new TaskDataBase(Path.Combine(_connectionString, _dataBaseName[0]));
            PeriodDB = new PeriodDataBase(Path.Combine(_connectionString, _dataBaseName[1]));
            ObjectDB = new ObjectDataBase(Path.Combine(_connectionString, _dataBaseName[2]));
            TypeDB = new TypeDataBase(Path.Combine(_connectionString, _dataBaseName[3]));
            SubTypeDB = new SubTypeDataBase(Path.Combine(_connectionString, _dataBaseName[4]));
            NotificationDB = new NotificationDataBase(Path.Combine(_connectionString, _dataBaseName[5]));
        }


    }
}
