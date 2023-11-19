using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class WaterControlFormConfig : IEntityTypeConfiguration<WaterControlForm>
    {
        public void Configure(EntityTypeBuilder<WaterControlForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(WaterControlForm));
            builder.Property(P => P.TotalHours).IsRequired();
            builder.Property(P => P.AmountWaterCaptured).IsRequired();
            builder.Property(P => P.AmountWaterSupplied).IsRequired();
            builder.Property(P => P.AluminumSulfate).IsRequired();
            builder.Property(P => P.SodiumHypochlorite).IsRequired();
            builder.Property(P => P.ChlorineGas).IsRequired();
            builder.Property(P => P.ParticlesPerMillion).IsRequired();

            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.WaterControlForm)
               .HasForeignKey(p => p.NationalIdentificationNumber)
               .HasPrincipalKey(p => p.NationalIdentificationNumber);

            builder.HasOne(p => p.IdPlantNavigation).WithMany(p => p.WaterControlForm)
             .HasForeignKey(p => p.IdPlant)
             .HasPrincipalKey(p => p.Id);
        }
    }
}
