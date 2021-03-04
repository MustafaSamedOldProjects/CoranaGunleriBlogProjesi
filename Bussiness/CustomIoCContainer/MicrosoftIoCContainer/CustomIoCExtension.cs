using Bussiness.Concrete;
using Bussiness.Interfaces;
using Bussiness.ValidationRules;
using Data.Concrete.EfCore.Repositories;
using Data.Interfaces;
using DTOs.Concrete.YaziDtoS;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.CustomIoCContainer.MicrosoftIoCContainer
{
     public static  class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            #region repoandservices

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IKategoriDal, EfKategoriRepository>();
            services.AddScoped<IKategoriService, KategoriManager>();

            services.AddScoped<IYaziDal, EfYaziRepository>();
            services.AddScoped<IYaziService, YaziManager>();

            services.AddScoped<IYaziKategoriDal, EfYaziKategoriRepository>();
            services.AddScoped<IYaziKategoriService, YaziKategoriManager>();

            services.AddScoped<ITagDal, EfTagRepository>();
            services.AddScoped<ITagService, TagManager>();

            services.AddScoped<IYaziTagDal, EfYaziTagRepository>();
            services.AddScoped<IYaziTagService, YaziTagManager>();

            services.AddScoped<IYaziYorumDal, EfYaziYorumRepository>();
            services.AddScoped<IYaziYorumService, YaziYorumManager>();

            services.AddScoped<IYorumDal, EfYorumRepository>();
            services.AddScoped<IYorumService, YorumManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();
            #endregion
            #region valid
            services.AddTransient<IValidator<YaziCreateDto>,YaziCreateValidator >();
            services.AddTransient<IValidator<YaziListDto>,YaziListValidator >();
            #endregion



        }

    }
}
