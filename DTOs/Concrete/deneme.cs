using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete
{
    public  class deneme
    {
        public int AppUserId { get; set; }
        public ICollection<Yazi> Yazis{ get; set; }
        public List<string> roller { get; set; }
        public string UserNama { get; set; }
        public List<AppUser> appUsers { get; set; }
        public List<AppRole> appRoles { get; set; }
    }
}
