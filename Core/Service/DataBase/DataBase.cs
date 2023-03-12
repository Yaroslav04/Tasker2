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
        public NotificationDataBase NotificationDB;
        public TypeDataBase TypeDB;
        public SubTypeDataBase SubTypeDB;

        public DataBase(string _connectionString, List<string> _dataBaseName)
        {
            TaskDB = new TaskDataBase(Path.Combine(_connectionString, _dataBaseName[0]));
            PeriodDB = new PeriodDataBase(Path.Combine(_connectionString, _dataBaseName[1]));
            ObjectDB = new ObjectDataBase(Path.Combine(_connectionString, _dataBaseName[2]));       
            NotificationDB = new NotificationDataBase(Path.Combine(_connectionString, _dataBaseName[3]));
            TypeDB = new TypeDataBase(Path.Combine(_connectionString, _dataBaseName[4]));
            SubTypeDB = new SubTypeDataBase(Path.Combine(_connectionString, _dataBaseName[5]));
        }


    }
}
