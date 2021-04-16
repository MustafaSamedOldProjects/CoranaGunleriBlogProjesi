using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete.AppUserDtoS
{
    public class TempDto
    {
        public int UId { get; set; }
        public string UName { get; set; }
        public string Urole { get; set; }
        public int RId { get; set; }
        public List<AppRole> appRoles { get; set; }
    }
}
