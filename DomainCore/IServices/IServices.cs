using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominCore.IServices
{
    public interface IServices<T> where T : class
    {
        //methods that we are going to use 
        Task<List<T>> GetAll();
        Task<T> FindById(string Id);
        Task<bool> Save(T entity);
        Task <bool> Delete(string Id);
        Task<bool> RoleExistsAsync(T entity);
    }
}
