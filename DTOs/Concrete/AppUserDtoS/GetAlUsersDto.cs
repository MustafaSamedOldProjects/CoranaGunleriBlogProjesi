using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete.AppUserDtoS
{
    public class GetAlUsersDto
    {
        public List<AppUser> appUserss { get; set; }
        public List<AppRole> appRoless { get; set; }
    }
}
