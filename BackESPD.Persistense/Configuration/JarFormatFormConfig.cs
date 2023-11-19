using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class JarFormatFormConfig : IEntityTypeConfiguration<JarFormatForm>
    {
        public void Configure(EntityTypeBuilder<JarFormatForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(JarFormatForm));
            builder.Property(P => P.JarConcentration).IsRequired();
            builder.Property(P => P.JarOptime).HasMaxLength(300).IsRequired();
            builder.Property(P => P.PhJar).IsRequired();

            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.JarFormatForm)
                .HasForeignKey(p => p.NationalIdentificationNumber)
                .HasPrincipalKey(p => p.NationalIdentificationNumber);

            builder.HasOne(p => p.IdPlantNavigation).WithOne(p => p.JarFormatForm)
                .HasForeignKey<JarFormatForm>(p => p.IdPlant)
                .HasPrincipalKey<Plant>(p => p.Id);
        }
    }
}
