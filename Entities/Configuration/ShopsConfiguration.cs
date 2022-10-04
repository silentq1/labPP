using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ShopsConfiguration : IEntityTypeConfiguration<Shops>
    {
        public void Configure(EntityTypeBuilder<Shops> builder)
        {
            builder.HasData
            (
            new Shops
            {
                Id = 1,
                Name = "Citylink",
                Address = "Botevgradskaya 12",
                Budget = 100,
            },
            new Shops
            {
                Id = 2,
                Name = "DNS",
                Address = "Bogdana Hmelnickogo 18",
                Budget = 400,
            }
            );
        }
    }
}
