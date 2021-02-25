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
            builder.HasKey(i => new
            {
                i.KategoriId,
                i.YaziId
            });
            builder.HasOne(i => i.Kategori).WithMany(i => i.YaziKategoris).HasForeignKey(i => i.KategoriId);
            builder.HasOne(i => i.Yazi).WithMany(i => i.YaziKategoris).HasForeignKey(i => i.YaziId);
        }
    }
}
