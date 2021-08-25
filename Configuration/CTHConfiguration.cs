using TrucknDriver.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrucknDriver.Configuration
{
    public class CTHConfiguration : IEntityTypeConfiguration<AccountTbl>
    {
        public void Configure(EntityTypeBuilder<AccountTbl> builder)
        {
            throw new NotImplementedException();
        }
    }
}
