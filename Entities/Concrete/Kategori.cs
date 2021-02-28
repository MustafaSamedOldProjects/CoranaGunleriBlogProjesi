using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Kategori : ITablo
    {
        public int Id { get; set; }
        public string KategoriIsmi { get; set; }
        public ICollection<YaziKategori> YaziKategoris { get; set; } = new List<YaziKategori>();
        //public ICollection<Kategori> Kategoris { get; set; } = new List<Kategori>();
        public Kategori ParentKategori { get; set; }
        public int? ParentKategoriId { get; set; }
        public ICollection<Kategori> SubKategoris { get; set; } = new List<Kategori>();
    }
}
