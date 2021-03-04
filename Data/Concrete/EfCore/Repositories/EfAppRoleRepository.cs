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
    public class EfAppRoleRepository :IAppRoleDal
    {
        public async Task<AppRole> GetAdminRole()
        {
            using BlogContext context = new BlogContext();
            return await context.Roles.Where(x => x.Name == RoleNames.Admin.ToString()).Select(x => new AppRole
            {
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<AppRole> GetMemberRole()
        {
            using BlogContext context = new BlogContext();
            return await context.Roles.Where(x => x.Name == RoleNames.Member.ToString()).Select(x => new AppRole
            {
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<AppRole> GetModeratorRole()
        {
            using BlogContext context = new BlogContext();
            return await context.Roles.Where(x => x.Name == RoleNames.Moderator.ToString()).Select(x => new AppRole
            {
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<AppRole> GetValidatorRole()
        {
            using BlogContext context = new BlogContext();
            return await context.Roles.Where(x => x.Name == RoleNames.Validator.ToString()).Select(x => new AppRole
            {
                Name = x.Name
            }).FirstOrDefaultAsync();
        }

        public async Task<AppRole> GetWriterRole()
        {
            using BlogContext context = new BlogContext();
            return await context.Roles.Where(x => x.Name == RoleNames.Writer.ToString()).Select(x => new AppRole
            {
                Name = x.Name
            }).FirstOrDefaultAsync();
        }
    }
}
