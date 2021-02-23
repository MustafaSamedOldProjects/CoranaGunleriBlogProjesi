using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Concrete.EfCore.Mapping
{
    public class YaziTagMap : IEntityTypeConfiguration<YaziTag>
    {
        public void Configure(EntityTypeBuilder<YaziTag> builder)
        {
            throw new NotImplementedException();
        }
    }
}
