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
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public ICollection<YaziKategori> YaziKategoris { get; set; }
        public ICollection<YaziTag> YaziTags{ get; set; }
        public int YaziTagId{ get; set; }
        public ICollection<YaziYorum> YaziYorums{ get; set; }
        public int YorumId{ get; set; }
    }
}
