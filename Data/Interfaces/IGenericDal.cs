using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGenericDal<T> where T : class, ITablo, new()
    {
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<T> GetLastId(T item);
    }
}
