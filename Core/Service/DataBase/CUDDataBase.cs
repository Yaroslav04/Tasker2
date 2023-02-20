using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker2.Core.Service.DataBase
{
    public class CUDDataBase<T>
    {
        public SQLiteAsyncConnection connection;

        public async Task<bool> SaveAsync(T obj) => await Save(obj);
        public async Task<bool> UpdateAsync(T obj) => await Update(obj);
        public async Task<bool> DeleteAsync(T obj) => await Delete(obj);
        public async Task<bool> SaveListAsync(List<T> list) => await SaveList(list);

        public async Task<bool> Save(T obj)
        {
            try
            {
                await connection.InsertAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> SaveList(List<T> list)
        {
            try
            {
                await connection.InsertAllAsync(list);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> Delete(T obj)
        {
            try
            {
                await connection.DeleteAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(T obj)
        {
            try
            {
                await connection.UpdateAsync(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
