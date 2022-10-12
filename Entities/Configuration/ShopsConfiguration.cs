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
    public class ShopsConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasData
            (
            new Shop
            {
                Id = 1,
                Name = "Citylink",
                Address = "Botevgradskaya 12",
                Budget = 100,
            },
            new Shop
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
