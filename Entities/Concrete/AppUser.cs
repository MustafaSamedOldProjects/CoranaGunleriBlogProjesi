using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<Yazi> Yazis { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
