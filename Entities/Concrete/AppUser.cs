using Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITablo
    {
        public ICollection<Yazi> Yazis { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Yorum> Yorums { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
