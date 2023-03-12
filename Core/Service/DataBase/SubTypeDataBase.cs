using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class SubTypeDataBase : CUDDataBase<TypeClass>
    {
        public SubTypeDataBase(string _connectionString)
        {
            connection = new SQLiteAsyncConnection(_connectionString);
            connection.CreateTableAsync<SubTypeClass>().Wait();
        }

        public async Task<List<SubTypeClass>> GetListAsync()
        {
            try
            {
                return await connection.Table<SubTypeClass>().ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<string>> GetTypesAsync(string _section, string _type)
        {
            try
            {
                List<string> types = new List<string>();
                foreach(var item in await connection.Table<SubTypeClass>().Where(x => x.Section == _section 
                & x.Type == _type ).ToListAsync())
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
