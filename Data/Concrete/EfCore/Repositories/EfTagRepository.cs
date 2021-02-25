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
           return await context.Tags.Join(context.Yazis, t => t.Id, y => y.YaziTagId, (t, y) => new
            {
                t,
                y
            }).Where(tt => tt.t.Id == tt.y.YaziTagId).Select(i => new Tag()
            {
                Id = i.t.Id,
                AppUser = i.t.AppUser,
                AppUserId = i.t.AppUserId,
                TagName = i.t.TagName,
                YaziTags = i.t.YaziTags
            }).ToListAsync();

        }
    }
}
