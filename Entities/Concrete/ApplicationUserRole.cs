using Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ApplicationUserRole : IdentityUserRole<int>, ITablo
    {
        public override int UserId { get; set; }
        public override int RoleId { get; set; }
    }
}
