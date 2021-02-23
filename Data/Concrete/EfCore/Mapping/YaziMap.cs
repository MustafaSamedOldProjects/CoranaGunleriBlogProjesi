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
            throw new NotImplementedException();
        }
    }
}
