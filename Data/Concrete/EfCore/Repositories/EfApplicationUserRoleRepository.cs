using Data.Concrete.EfCore.Context;
using Data.Interfaces;
using DTOs;
using DTOs.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EfCore.Repositories
{
    public class EfApplicationUserRoleRepository : IApplicationUserRoleDal
    {
        public async Task<AppUserWithRoleDto> GetirUserIdyKarşılıkGelenRoleIdYiAsync(int id)
        {
            using BlogContext  context= new BlogContext();
            var bak = await context.ApplicationUserRoles.Select(i => new AppRole()
            {
                Id = i.RoleId
            }).ToListAsync();
            var bak2 = await context.AppUsers.Include(au => au.Yazis).Select(i => new deneme
            {
                AppUserId = i.Id,
                Yazis = i.Yazis

            }).ToListAsync();

            return await context.AppUsers.Include(au => au.UserRoles).Select(i => new AppUserWithRoleDto
            {
                UserId = i.Id,
                ApplicationUserRoles = i.UserRoles,
                RoleId = i.UserRoles.FirstOrDefault().RoleId
            }).FirstOrDefaultAsync();
            //return await context.ApplicationUserRoles.Where(i => i.UserId == id).Select(i => new ApplicationUserRole()
            //{
            //    UserId = id,
            //    RoleId = i.RoleId
            //}).FirstOrDefaultAsync() ;
        }
    }
}
