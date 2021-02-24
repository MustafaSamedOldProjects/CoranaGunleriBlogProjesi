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
    public class EfKategoriRepository : EfGenericRepository<Kategori>, IKategoriDal
    {
        public async Task<List<Kategori>> GetKategorisHaveNoYazis()
        {
            using BlogContext context = new BlogContext();
            return await context.Kategoris.Join(context.YaziKategoris, i => i.Id, i => i.KategoriId, (k, yk) => new {
                k,
                yk
            }).Where(x => x.yk.Kategori == null).Select(i => new Kategori
            {
                KategoriIsmi = i.k.KategoriIsmi
            }).ToListAsync();
        }

        public async Task<List<Kategori>> GetKategorisHaveYazis()
        {
            using BlogContext context = new BlogContext();
            return await context.Kategoris.Join(context.YaziKategoris, i => i.Id, i => i.KategoriId, (k, yk) => new {
                k,
                yk
            }).Where(x => x.yk.Kategori != null).Select(i => new Kategori
            {
                KategoriIsmi = i.k.KategoriIsmi
            }).ToListAsync();
        }
    }
}
