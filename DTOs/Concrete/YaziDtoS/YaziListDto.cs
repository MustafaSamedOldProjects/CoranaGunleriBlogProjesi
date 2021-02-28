using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete.YaziDtoS
{
    public class YaziListDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public  byte[] GorunurResmi;
        //public byte[] GorunurResmi { get; set; }
        public string BeklemeDurumu { get; set; }
        public DateTime YazıldıgıTarih { get; set; }
        public AppUser AppUser { get; set; }
        public Kategori Kategori { get; set; }
        public Tag Tag { get; set; }
    }
}
