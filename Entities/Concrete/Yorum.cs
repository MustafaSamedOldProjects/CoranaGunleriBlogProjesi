using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Yorum : ITablo
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string BeklemeDurumu { get; set; }
        public DateTime YazildigiTarih { get; set; }
        public AppUser appUser { get; set; }
    }
}
