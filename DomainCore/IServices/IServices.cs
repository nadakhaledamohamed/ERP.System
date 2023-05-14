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
        Task<T> FindById(int id);
        Task<bool> Save(T entity);
        Task Delete(string Id);
        
    }
}
