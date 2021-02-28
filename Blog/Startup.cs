using Blog.Seed;
using Bussiness.CustomIoCContainer.MicrosoftIoCContainer;
using Data.Concrete.EfCore.Context;
using Entities.Concrete;
using Entities.StringInfos;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<BlogContext>();
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Lockout.MaxFailedAccessAttempts = 3;
                //opt.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<BlogContext>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/Index");
                opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
                opt.Cookie.HttpOnly = true;
                opt.Cookie.Name = "UdemyCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
            });
            services.AddDependencies();
            services.AddTransient<Tag>();
            services.AddHttpContextAccessor();
            services.AddControllersWithViews().AddFluentValidation();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleNames.Admin.ToString(),
                    authBuilder =>
                    {
                        authBuilder.RequireRole(RoleNames.Admin.ToString());
                    });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleNames.Moderator.ToString(),
                    authBuilder =>
                    {
                        authBuilder.RequireRole(RoleNames.Moderator.ToString());
                    });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleNames.Validator.ToString(),
                    authBuilder =>
                    {
                        authBuilder.RequireRole(RoleNames.Validator.ToString());
                    });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleNames.Writer.ToString(),
                    authBuilder =>
                    {
                        authBuilder.RequireRole(RoleNames.Writer.ToString());
                    });
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleNames.Member.ToString(),
                    authBuilder =>
                    {
                        authBuilder.RequireRole(RoleNames.Member.ToString());
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(env.ContentRootPath, "wwwroot/AnaKlasor/Resimler")),
                RequestPath = "/wwwroot/AnaKlasor/Resimler"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                        Path.Combine(env.ContentRootPath, "wwwroot/AnaKlasor/Yazilar")),
                RequestPath = "/wwwroot/AnaKlasor/Yazilar"
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            Seeding.SeedData(userManager, roleManager).Wait();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
