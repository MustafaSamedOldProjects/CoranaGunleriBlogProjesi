using AutoMapper;
using DTOs.Concrete;
using DTOs.Concrete.YaziDtoS;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Map
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<SignInIdentityDto, AppUser>();
            CreateMap<SignUpIdentityDto, AppUser>();
            CreateMap<AppUser, SignInIdentityDto>();
            CreateMap<AppUser, SignUpIdentityDto>();


            CreateMap<YaziListDto, Yazi>();
            CreateMap<Yazi, YaziListDto>();

            CreateMap<YaziDetailstDto, Yazi>();
            CreateMap<Yazi, YaziDetailstDto>();


            CreateMap<YaziCreateDto, Yazi>();
            CreateMap<Yazi, YaziCreateDto>();

        }
    }
}
