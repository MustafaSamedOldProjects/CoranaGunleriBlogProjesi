using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class YaziKategori : ITablo
    {
        public Kategori Kategori { get; set; }
        public int KategoriId { get; set; }
        public Yazi Yazi { get; set; }
        public int YaziId { get; set; }
    }
}
