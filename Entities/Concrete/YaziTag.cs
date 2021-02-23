using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class YaziTag
    {
        public int YaziId { get; set; }
        public Yazi Yazi { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
