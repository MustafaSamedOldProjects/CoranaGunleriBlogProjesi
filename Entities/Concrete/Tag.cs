using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Tag : ITablo
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public ICollection<YaziTag> YaziTags { get; set; }
        //public Tag ParentTag { get; set; }
        //public int? ParentTagId { get; set; }
        //public ICollection<Tag> SubTags { get; set; }
        public AppUser AppUser { get; set; }
    }
}
