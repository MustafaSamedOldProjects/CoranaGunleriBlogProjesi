using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete.AppUserDtoS
{
    public class GetAllUsersDtoHelper
    {
        public AppUser appUsers { get; set; }
        public AppRole appRoles { get; set; }
    }
}
