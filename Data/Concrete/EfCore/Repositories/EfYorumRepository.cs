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
    public class EfYorumRepository : EfGenericRepository<Yorum>, IYorumDal
    {
        public async Task<ICollection<Yorum>> GetirYorumsByYaziId(int id)
        {
            using BlogContext context = new BlogContext();
            return await context.Yorums.Join(context.YaziYorums, y => y.Id, yy => yy.YorumId, (y, yy) => new
            {
                y,
                yy
            }).Join(context.Yazis, tt => tt.yy.YaziId, yaz => yaz.Id, (tt, yaz) => new
            {
                tt,
                yaz
            }).Where(i => i.yaz.Id == i.tt.yy.YaziId).Select(i => new Yorum()
            {

                Body = i.tt.y.Body,
                BeklemeDurumu = i.tt.y.BeklemeDurumu,
                ParentYorum = i.tt.y.ParentYorum,
                SubYorums = i.tt.y.SubYorums,
                YazildigiTarih = i.tt.y.YazildigiTarih,
                ParentYorumId = i.tt.y.ParentYorumId,
                Id = i.tt.y.Id,
                AppUser = i.tt.y.AppUser

            }).ToListAsync();

        }
    }
}
