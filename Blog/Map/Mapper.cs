using AutoMapper;
using DTOs.Concrete;
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
        }
    }
}
