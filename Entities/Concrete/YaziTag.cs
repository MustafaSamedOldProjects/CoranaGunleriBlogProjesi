using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class YaziTag : ITablo
    {
        public int YaziId { get; set; }
        public Yazi Yazi { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
