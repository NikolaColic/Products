using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Data.Interfaces
{
    public interface IJsonService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Add(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(int id);
    }
}
