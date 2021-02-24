using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class KategoriMap : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasKey(i=> i.Id);
            builder.HasMany(i => i.YaziKategoris).WithOne(i => i.Kategori).HasForeignKey(i=> i.KategoriId);
            builder.HasMany(i => i.SubKategoris).WithOne(i=> i.ParentKategori).HasForeignKey(i=> i.ParentKategoriId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
