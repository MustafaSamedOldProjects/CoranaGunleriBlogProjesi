using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class YaziMap : IEntityTypeConfiguration<Yazi>
    {
        public void Configure(EntityTypeBuilder<Yazi> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasMany(i => i.YaziKategoris).WithOne(i=> i.Yazi).HasForeignKey(i=> i.YaziId);
            builder.HasOne(i => i.AppUser).WithMany(i=> i.Yazis).HasForeignKey(i=> i.Id);

        }
    }
}
