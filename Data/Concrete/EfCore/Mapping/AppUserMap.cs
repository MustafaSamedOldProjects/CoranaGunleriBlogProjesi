using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(i => i.Yazis).WithOne(i => i.AppUser).HasForeignKey(i => i.Id);
            builder.HasMany(i => i.Tags).WithOne(i => i.AppUser).HasForeignKey(i => i.Id);
            builder.HasMany(i => i.Yorums).WithOne(i => i.AppUser).HasForeignKey(i => i.Id);
        }
    }
}
