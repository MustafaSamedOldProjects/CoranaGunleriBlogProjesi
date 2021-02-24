using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class GenericManager<T>  : IGenericService<T> where T : class, ITablo, new()
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task Add(T item)
        {
             await _genericDal.Add(item);
        }

        public async Task Delete(T item)
        {
            await _genericDal.Delete(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _genericDal.GetAll();
        }

        public async Task<T> GetById(int id)
        {
             return await _genericDal.GetById(id);
        }

        public async Task<T> GetLastId(T item)
        {
            return await _genericDal.GetLastId(item);
        }

        public async Task Update(T item)
        {
             await _genericDal.Update(item);
        }
    }
}
