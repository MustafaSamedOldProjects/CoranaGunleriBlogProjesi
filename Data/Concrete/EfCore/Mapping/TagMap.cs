using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(i => i.YaziTags).WithOne(i => i.Tag).HasForeignKey(i=> i.TagId);
            builder.HasOne(i => i.AppUser).WithMany(i => i.Tags).HasForeignKey(i=> i.AppUserId);
        }
    }
}
