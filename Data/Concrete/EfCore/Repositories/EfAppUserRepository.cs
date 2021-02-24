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
    public class EfAppUserRepository :IAppUserDal
    {
        public async Task<List<AppUser>> GetAdmins()
        {
            using BlogContext context = new BlogContext();
            return await context.Users.Join(context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new {
                u,
                ur
            }).Join(context.Roles, ttr => ttr.ur.RoleId, r => r.Id, (ttr, r) => new {
                ttr,
                r
            }).Where(x => x.r.Name == RoleNames.Admin.ToString()).Select(i => new AppUser
            {
                UserName = i.ttr.u.UserName,
                Id = i.ttr.u.Id
            }).ToListAsync();
        }

        public async Task<List<AppUser>> GetMembers()
        {
            using BlogContext context = new BlogContext();
            return await context.Users.Join(context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new {
                u,
                ur
            }).Join(context.Roles, ttr => ttr.ur.RoleId, r => r.Id, (ttr, r) => new {
                ttr,
                r
            }).Where(x => x.r.Name == RoleNames.Member.ToString()).Select(i => new AppUser
            {
                UserName = i.ttr.u.UserName,
                Id = i.ttr.u.Id
            }).ToListAsync();
        }

        public async Task<List<AppUser>> GetModerators()
        {
            using BlogContext context = new BlogContext();
            return await context.Users.Join(context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new {
                u,
                ur
            }).Join(context.Roles, ttr => ttr.ur.RoleId, r => r.Id, (ttr, r) => new {
                ttr,
                r
            }).Where(x => x.r.Name == RoleNames.Moderator.ToString()).Select(i => new AppUser
            {
                UserName = i.ttr.u.UserName,
                Id = i.ttr.u.Id
            }).ToListAsync();
        }

        public async Task<List<AppUser>> GetValidators()
        {
            using BlogContext context = new BlogContext();
            return await context.Users.Join(context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new {
                u,
                ur
            }).Join(context.Roles, ttr => ttr.ur.RoleId, r => r.Id, (ttr, r) => new {
                ttr,
                r
            }).Where(x => x.r.Name == RoleNames.Validator.ToString()).Select(i => new AppUser
            {
                UserName = i.ttr.u.UserName,
                Id = i.ttr.u.Id
            }).ToListAsync();
        }

        public async Task<List<AppUser>> GetWriters()
        {
            using BlogContext context = new BlogContext();
            return await context.Users.Join(context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new {
                u,
                ur
            }).Join(context.Roles, ttr => ttr.ur.RoleId, r => r.Id, (ttr, r) => new {
                ttr,
                r
            }).Where(x => x.r.Name == RoleNames.Writer.ToString()).Select(i => new AppUser
            {
                UserName = i.ttr.u.UserName,
                Id = i.ttr.u.Id
            }).ToListAsync();
        }
    }
}
