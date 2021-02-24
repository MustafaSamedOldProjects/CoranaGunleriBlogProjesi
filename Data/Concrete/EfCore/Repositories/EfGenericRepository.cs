using Data.Concrete.EfCore.Context;
using Data.Interfaces;
using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, ITablo, new()
    {
        public async Task Add(T item)
        {
            using BlogContext context = new BlogContext();
            await context.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            using BlogContext context = new BlogContext();
            context.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            using BlogContext context = new BlogContext();
            return await context.Set<T>().ToListAsync();
        }

        public async  Task<T> GetById(int id)
        {
            using BlogContext context = new BlogContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async  Task<T> GetLastId(T item)
        {
            using BlogContext context = new BlogContext();
            return  await context.Set<T>().OrderBy(x => x.GetType().GetProperty("Id").GetValue(x, null)).FirstOrDefaultAsync(); ;
        }

        public async Task Update(T item)
        {
            using BlogContext context = new BlogContext();
            var a = context.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
