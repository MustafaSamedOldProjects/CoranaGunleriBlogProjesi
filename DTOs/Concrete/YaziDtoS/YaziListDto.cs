using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete.YaziDtoS
{
    public class YaziListDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Location { get; set; }
        public  byte[] GorunurResmi;
        //public byte[] GorunurResmi { get; set; }
        public string BeklemeDurumu { get; set; }
        public DateTime YazıldıgıTarih { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public ICollection<Kategori> Kategori { get; set; }
        public ICollection<Tag> Tag { get; set; }
    }
}
