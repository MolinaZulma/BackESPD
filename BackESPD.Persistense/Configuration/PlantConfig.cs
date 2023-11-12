using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackESPD.Persistense.Configuration
{
    public class PlantConfig : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(Plant));
            builder.Property(p => p.TypePlant).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Direction).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
        }
    }
}
 
