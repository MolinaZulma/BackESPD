using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class SampleFormConfig : IEntityTypeConfiguration<SampleForm>
    {
        public void Configure(EntityTypeBuilder<SampleForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(SampleForm));
            builder.Property(P => P.SampleNumber).IsRequired();
            builder.Property(P => P.MediumFlow).IsRequired();
            builder.Property(P => P.TemperatureC ).IsRequired();
            builder.Property(P => P.Ph ).IsRequired();
            builder.Property(P => P.CreamWeightKilos ).IsRequired();
            builder.Property(P => P.SiftingWeightKilos ).IsRequired();
            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.SampleForm)
               .HasForeignKey(p => p.NationalIdentificationNumber)
               .HasPrincipalKey(p => p.NationalIdentificationNumber);

            builder.HasOne(p => p.IdPlantNavigation).WithMany(p => p.SampleForm)
            .HasForeignKey(p => p.IdPlant)
            .HasPrincipalKey(p => p.Id);

        }
    }
}
