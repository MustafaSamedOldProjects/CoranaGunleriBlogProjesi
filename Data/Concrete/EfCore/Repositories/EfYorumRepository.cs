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
            return await context.Yorums.Join(context.Yazis, y => y.Id, y => y.YorumId, (yo, ya) => new
            {
                yo,
                ya
            }).Where(i => i.yo.Id == i.ya.YorumId).Select(i => new Yorum()
            {
                Id = i.yo.Id,
                AppUser = i.yo.AppUser,
                AppUserId = i.yo.AppUserId,
                BeklemeDurumu = i.yo.BeklemeDurumu,
                Body = i.yo.Body,
                YazildigiTarih = i.yo.YazildigiTarih,
                YaziYorums = i.yo.YaziYorums
            }).ToListAsync(); ;
        }
    }
}
