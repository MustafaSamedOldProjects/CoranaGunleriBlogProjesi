using Data.Concrete.EfCore.Context;
using Data.Interfaces;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Repositories
{
    public class EfYaziKategoriRepository : EfGenericRepository<YaziKategori>, IYaziKategoriDal
    {
        public async Task<List<YaziKategori>> GetYaziKategoris(int[] kategoriler)
        {
            using BlogContext context = new BlogContext();
            return await context.YaziKategoris.Where(i => kategoriler.Contains(i.KategoriId)).Select(İ => new YaziKategori()
            {
                KategoriId = İ.KategoriId
            }).ToListAsync();
        }
    }
}
