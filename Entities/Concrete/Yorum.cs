using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Yorum
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string BeklemeDurumu { get; set; }
        public DateTime YazildigiTarih { get; set; }
        public AppUser appUser { get; set; }
    }
}
