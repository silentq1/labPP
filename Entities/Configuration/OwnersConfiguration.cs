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
    public class OwnersConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasData
            (
            new Owner
            {
                Id = 1,
                Name = "Ivanov Ivan Ivanovich",
                Address = "Wall st. 1"
            },
            new Owner
            {
                Id = 2,
                Name = "Petrov Ivan Sergeevich",
                Address = "Sevastopolskaya st. 24"
            }
            );
        }
    }
}
