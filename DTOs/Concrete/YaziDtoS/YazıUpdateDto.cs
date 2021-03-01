using DTOs.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete.YaziDtoS
{
    public class YazıUpdateDto :  IDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public byte[] GorunurResmi { get; set; }
        public string Body { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public int[] TagId { get; set; }
        public ICollection<Kategori> Kategoris { get; set; } = new List<Kategori>();
        public int[] KategoriId { get; set; }
    }
}
