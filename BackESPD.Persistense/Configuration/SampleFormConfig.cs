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
    public class SampleFormConfig : IEntityTypeConfiguration<SampleForm>
    {
        public void Configure(EntityTypeBuilder<SampleForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(SampleForm));
            builder.Property(P => P.SampleNumber).IsRequired();
            builder.Property(P => P.Date).IsRequired();
            builder.Property(P => P.MediumFlow).IsRequired();
            builder.Property(P => P.TemperatureC ).IsRequired();
            builder.Property(P => P.Ph ).IsRequired();
            builder.Property(P => P.CreamWeightKilos ).IsRequired();
            builder.Property(P => P.SiftingWeightKilos ).IsRequired();
            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.SampleForm)
               .HasForeignKey(p => p.IdUser)
               .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.IdPlantNavigation).WithOne(p => p.SampleForm)
                .HasForeignKey<SampleForm>(p => p.IdPlant)
                .HasPrincipalKey<Plant>(p => p.Id);

        }
    }
}
