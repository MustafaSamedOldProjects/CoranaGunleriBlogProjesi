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
            throw new NotImplementedException();
        }
    }
}
