using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class YaziYorumMap : IEntityTypeConfiguration<YaziYorum>
    {
        public void Configure(EntityTypeBuilder<YaziYorum> builder)
        {
            builder.HasKey(i => new
            {
                i.YorumId,
                i.YaziId
            });
            builder.HasOne(i => i.Yazi).WithMany(i => i.YaziYorums).HasForeignKey(i=> i.YaziId);
            builder.HasOne(i => i.Yorum).WithMany(i => i.YaziYorums).HasForeignKey(i=> i.YorumId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
