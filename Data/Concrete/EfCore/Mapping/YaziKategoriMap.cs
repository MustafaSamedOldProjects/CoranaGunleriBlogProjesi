using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class YaziKategoriMap : IEntityTypeConfiguration<YaziKategori>
    {
        public void Configure(EntityTypeBuilder<YaziKategori> builder)
        {
            throw new NotImplementedException();
        }
    }
}
