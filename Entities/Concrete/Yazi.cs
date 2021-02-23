using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Yazi : ITablo
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public byte[] GorunurResmi { get; set; }
        public string BeklemeDurumu { get; set; }
        public DateTime YazıldıgıTarih { get; set; }
        public AppUser YazanKisi { get; set; }
    }
}
