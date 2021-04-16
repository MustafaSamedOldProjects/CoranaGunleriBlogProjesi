using Data.Concrete.EfCore.Context;
using Data.Interfaces;
using DTOs.Concrete.AppUserDtoS;
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
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
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

        public async Task<List<AppUser>> GetAllUsers()
        {
            using BlogContext context = new BlogContext();
            return await context.AppUsers.Select(i => new AppUser()
            {
                Id = i.Id,
                UserName = i.UserName
            }).ToListAsync() ;


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

        public async Task<List<AppUser>> GetUsersByYaziId(int id)
        {
            using BlogContext context = new BlogContext();
            return await context.Users.Join(context.Yazis, u => u.Id, y => y.AppUserId, (u, y) => new {
                u,
                y
            }).Where(x => x.y.Id== id).Select(i => new AppUser
            {
                UserName = i.u.UserName,
                Id = i.u.Id,
                
            }).ToListAsync();
        }

        //public async Task<List<AppUser>> GetUserWithRole()
        //{
        //    BlogContext context = new BlogContext();

        //    return await context.AppUsers.Include(i => i.).ThenInclude(i=> i.).ToListAsync();
        //    //    .Join(context.UserRoles, u => u.Id, ur => ur.UserId, (ıı, ur) => new
        //    //{
        //    //    ıı,
        //    //    ur
        //    //}).Join(context.Roles, ttr => ttr.ur.RoleId, r => r.Id, (ttr, r) => new
        //    //{
        //    //    ttr,
        //    //    r
        //    //}).Where(i => i.ttr.ıı.Id == i.r.Id).Select(i => new TempDto()
        //    //{
        //    //    appUser = i.ttr.ıı,

        //    //}).ToListAsync() ;

        //}

        //public async Task<List<GetAllUsersDtoHelper>> GetUserWithRole()
        //{
        //    using BlogContext context = new BlogContext();


        //    //var appuser =  await context.Users.Join(context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new
        //    //{
        //    //    u,
        //    //    ur
        //    //}).Join(context.Roles, ttr => ttr.ur.RoleId, r => r.Id, (ttr, r) => new
        //    //{
        //    //    ttr,
        //    //    r
        //    //}).Where(x => x.ttr.ur.RoleId == x.r.Id).Select(i => new AppUser
        //    //{
        //    //    Id = i.ttr.u.Id,
        //    //    Email = i.ttr.u.Email,
        //    //    Tags = i.ttr.u.Tags,
        //    //    UserName = i.ttr.u.UserName



        //    //}).ToListAsync();

        //    //var approle = await context.AppRoles.Select(i=> new AppRole() { 
        //    //Id =i.Id,
        //    //Name =i.Name
        //    //}).ToListAsync();

        //    //List<GetAllUsersDtoHelper> GetAllUsersDtoHelper = new List<GetAllUsersDtoHelper>();

        //    //foreach (var item in appuser)
        //    //{
        //    //    GetAllUsersDtoHelper.Add(new GetAllUsersDtoHelper() { 
        //    //    appUsers = item
        //    //    });
        //    //}
        //    //return 0;
        //}

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
