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
    public class EfTagRepository : EfGenericRepository<Tag>, ITagDal
    {
        public async Task<ICollection<Tag>> GetirTagsByYaziId()
        {
            using BlogContext context = new BlogContext();
           return await context.Tags.Join(context.YaziTags, t => t.Id, yt => yt.TagId, (t, yt) => new
            {
                t,
                yt
            }).Join(context.Yazis,i => i.yt.YaziId,i=> i.Id,(tt,y) => new { 
            tt,
            y
            }).Where(i =>i.y.Id == i.tt.yt.YaziId).Select(i => new Tag()
            {
                Id = i.tt.t.Id,
                AppUser = i.tt.t.AppUser,
                TagName = i.tt.t.TagName,
                YaziTags = i.tt.t.YaziTags
            }).ToListAsync();

        }
    }
}
