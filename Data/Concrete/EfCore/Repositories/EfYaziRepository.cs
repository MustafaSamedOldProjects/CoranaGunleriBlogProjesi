using Data.Concrete.EfCore.Context;
using Data.Interfaces;
using Entities.Concrete;
using Entities.StringInfos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Repositories
{
    public class EfYaziRepository : EfGenericRepository<Yazi>, IYaziDal
    {
        public async Task<List<Yazi>> GetBekleyenYazilar()
        {
            using BlogContext context = new BlogContext();
            return await context.Yazis.Where(i => i.BeklemeDurumu == OnayDurumlari.OnayBekliyor.ToString()).ToListAsync();
        }

        public async Task<List<Yazi>> GetOnaylananYazilar()
        {
            using BlogContext context = new BlogContext();
            return await context.Yazis.Where(i => i.BeklemeDurumu == OnayDurumlari.Onaylandı.ToString()).ToListAsync();
        }

        public async Task<List<Yazi>> GetOnaylanMayanYazilar()
        {
            using BlogContext context = new BlogContext();
            return await context.Yazis.Where(i => i.BeklemeDurumu == OnayDurumlari.Onaylanmadi.ToString()).ToListAsync();
        }

        public async Task<List<Yazi>> GetSilinenYazilar()
        {
            using BlogContext context = new BlogContext();
            return await context.Yazis.Where(i => i.BeklemeDurumu == OnayDurumlari.Silindi.ToString()).ToListAsync();
        }

        public async Task<List<Yazi>> GetYazi()
        {
            using BlogContext context = new BlogContext();
            return await context.Yazis.Join(context.Users, y => y.AppUser.Id, u => u.Id, (y, u) => new
            {
                y,
                u
            }).Where(tt => tt.y.AppUser.Id == tt.u.Id ).Select(i => new Yazi()
            {
                Id = i.y.Id,
                AppUser= i.y.AppUser,
                BeklemeDurumu= i.y.BeklemeDurumu,
                GorunurResmi= i.y.GorunurResmi,
                Location= i.y.Location,
                YaziTags= i.y.YaziTags,
                YaziYorums= i.y.YaziYorums,
                YazıldıgıTarih= i.y.YazıldıgıTarih,
                YaziKategoris= i.y.YaziKategoris
            }).ToListAsync();
        }
        public async Task<List<AppUser>> GetYaziSahipUsers()
        {
            using BlogContext context = new BlogContext();
            return await context.Yazis.Join(context.Users, y => y.AppUser.Id, u => u.Id, (y, u) => new
            {
                y,
                u
            }).Where(tt => tt.y.AppUser.Id == tt.u.Id).Select(i => new AppUser()
            {
                Id = i.u.Id,
                UserName = i.u.UserName,
                Email = i.u.Email,
            }).ToListAsync();
        }
    }
}
