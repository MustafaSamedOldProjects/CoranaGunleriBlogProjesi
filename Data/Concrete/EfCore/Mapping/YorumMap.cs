using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class YorumMap : IEntityTypeConfiguration<Yorum>
    {
        public void Configure(EntityTypeBuilder<Yorum> builder)
        {
            builder.HasMany(i => i.YaziYorums).WithOne(i => i.Yorum).HasForeignKey(i=> i.YorumId) ;
            builder.HasOne(i => i.AppUser).WithMany(i => i.Yorums).HasForeignKey(i=> i.AppUserId);
            builder.HasOne(i => i.ParentYorum).WithMany(i => i.SubYorums).HasForeignKey(i=> i.ParentYorumId);
        }
    }
}
