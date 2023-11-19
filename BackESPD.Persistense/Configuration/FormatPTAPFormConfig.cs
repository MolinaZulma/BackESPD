using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class FormatPTAPFormConfig : IEntityTypeConfiguration<FormatPTAPForm>
    {
        public void Configure(EntityTypeBuilder<FormatPTAPForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(FormatPTAPForm));
            builder.Property(P => P.TypeWater).IsRequired();
            builder.Property(P => P.Temperature).IsRequired();
            builder.Property(P => P.AlkalinityPh).IsRequired();
            builder.Property(P => P.AlkalineChlorine).IsRequired();
            builder.Property(P => P.AlkalineInitialReading).IsRequired();
            builder.Property(P => P.AlkalineFinalReading).IsRequired();
            builder.Property(P => P.AlkalineTotal).IsRequired();
            builder.Property(P => P.Alkaline).IsRequired();
            builder.Property(P => P.ChlorineGas).IsRequired();
            builder.Property(P => P.ParticlesPerMillion).IsRequired();

            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.FormatPTAPForms)
                .HasForeignKey(p => p.NationalIdentificationNumber)
                .HasPrincipalKey(p => p.NationalIdentificationNumber);

            builder.HasOne(p => p.IdPlantNavigation).WithMany(p => p.FormatPTAPForm)
                .HasForeignKey(p => p.IdPlant)
                .HasPrincipalKey(p => p.Id);

        }
    }
}
