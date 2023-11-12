using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackESPD.Persistense.Configuration
{
    public class WaterControlFormConfig : IEntityTypeConfiguration<WaterControlForm>
    {
        public void Configure(EntityTypeBuilder<WaterControlForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(WaterControlForm));
            builder.Property(P => P.Date).IsRequired();
            builder.Property(P => P.TotalHours).IsRequired();
            builder.Property(P => P.AmountWaterCaptured).IsRequired();
            builder.Property(P => P.AmountWaterSupplied).IsRequired();
            builder.Property(P => P.AluminumSulfate).IsRequired();
            builder.Property(P => P.SodiumHypochlorite).IsRequired();
            builder.Property(P => P.ChlorineGas).IsRequired();
            builder.Property(P => P.ParticlesPerMillion).IsRequired();

            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.WaterControlForm)
               .HasForeignKey(p => p.IdUser)
               .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.IdPlantNavigation).WithOne(p => p.WaterControlForm)
                .HasForeignKey<WaterControlForm>(p => p.IdPlant)
                .HasPrincipalKey<Plant>(p => p.Id);
        }
    }
}
