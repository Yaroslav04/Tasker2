using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class TypeDataBase : CUDDataBase<TypeClass>
    {
        public TypeDataBase(string _connectionString)
        {
            connection = new SQLiteAsyncConnection(_connectionString);
            connection.CreateTableAsync<TypeClass>().Wait();
        }

        public async Task<List<TypeClass>> GetListAsync()
        {
            try
            {
                return await connection.Table<TypeClass>().ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<string>> GetTypesAsync(string _section)
        {
            try
            {
                List<string> types = new List<string>();
                foreach(var item in await connection.Table<TypeClass>().Where(x => x.Section == _section).ToListAsync())
                {
                    types.Add(item.Name);
                }
                types = types.OrderBy(x => x).ToList();
                return types;
            }
            catch
            {
                return null;
            }
        }
    }
}
