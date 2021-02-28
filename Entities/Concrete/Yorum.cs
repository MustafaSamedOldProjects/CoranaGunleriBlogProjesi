using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Yorum : ITablo
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string BeklemeDurumu { get; set; }
        public DateTime YazildigiTarih { get; set; }
        public Yorum ParentYorum { get; set; }
        public int? ParentYorumId { get; set; }
        public ICollection<Yorum> SubYorums { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public ICollection<YaziYorum> YaziYorums { get; set; }
    }
}
