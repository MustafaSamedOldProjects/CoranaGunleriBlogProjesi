using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Concrete.YaziDtoS
{
    public class YaziCreateDto
    {
        public byte[] GorunurResmi { get; set; }
        public string Body { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public int TagId { get; set; }
        public ICollection<Kategori> Kategoris{ get; set; } = new List<Kategori>();
        public int KategoriId{ get; set; }

    }
}
