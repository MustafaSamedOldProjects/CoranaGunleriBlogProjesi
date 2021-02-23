using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriIsmi { get; set; }
        public ICollection<Kategori> Kategoris { get; set; }
        public Kategori ParentKategori { get; set; }
        public int? ParentKategoriId { get; set; }
        public ICollection<Kategori> SubKategoris { get; set; } = new List<Kategori>();
    }
}
