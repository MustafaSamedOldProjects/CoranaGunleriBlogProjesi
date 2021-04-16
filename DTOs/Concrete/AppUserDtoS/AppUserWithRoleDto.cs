using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class AppUserWithRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
