using Bussiness.Interfaces;
using Entities.Concrete;
using Entities.StringInfos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Seed
{
    public static class Seeding
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IKategoriService kategoriService, ITagService tagService)
        {
            var adminRole = await roleManager.FindByNameAsync(RoleNames.Admin.ToString()) ;
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = RoleNames.Admin.ToString() });
            }

            var memberRole = await roleManager.FindByNameAsync(RoleNames.Member.ToString());
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = RoleNames.Member.ToString() });
            }
            var modRole = await roleManager.FindByNameAsync(RoleNames.Moderator.ToString());
            if (modRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = RoleNames.Moderator.ToString() });
            }
            var valRole = await roleManager.FindByNameAsync(RoleNames.Validator.ToString());
            if (valRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = RoleNames.Validator.ToString() });
            }
            var wriRole = await roleManager.FindByNameAsync(RoleNames.Writer.ToString());
            if (wriRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = RoleNames.Writer.ToString() });
            }

            var adminUser = await userManager.FindByNameAsync("mustafa");
            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "mustafa",
                    Email = "mustafa@gmail.com"
                };
                await userManager.CreateAsync(user, "mustafa");
                await userManager.AddToRoleAsync(user, RoleNames.Admin.ToString());
            }
            var kategoriler = kategoriService.GetAll();
            if (kategoriler.Result.Count < 1)
            {
                await kategoriService.Add(new Kategori()
                {

                    KategoriIsmi = "Hakkımda"
                });
                await kategoriService.Add(new Kategori()
                {

                    KategoriIsmi = "İletisim"
                });
                await kategoriService.Add(new Kategori()
                {

                    KategoriIsmi = "Karalamalar"
                });
            }
            var tagler = tagService.GetAll();
            if (tagler.Result.Count < 1)
            {
                await tagService.Add(new Tag()
                {

                    TagName = "Duygusal",
                    //AppUser = userManager.FindByNameAsync("mustafa").Result,
                    AppUserId = userManager.FindByNameAsync("mustafa").Result.Id
                }); ;
                await tagService.Add(new Tag()
                {
                    //AppUser = userManager.FindByNameAsync("mustafa").Result,
                    TagName = "Yenilikçi",
                    AppUserId = userManager.FindByNameAsync("mustafa").Result.Id

                });
                await tagService.Add(new Tag()
                {
                    //AppUser = userManager.FindByNameAsync("mustafa").Result,
                    TagName = "İşe yarar",
                    AppUserId = userManager.FindByNameAsync("mustafa").Result.Id

                });
            }
        }
    }
}
