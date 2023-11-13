using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class DamageReportConfig : IEntityTypeConfiguration<DamageReport>
    {
        public void Configure(EntityTypeBuilder<DamageReport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(DamageReport));            
            builder.Property(P => P.AddressDamage).HasMaxLength(300).IsRequired();
            builder.Property(P => P.DescriptionDamage).HasMaxLength(500).IsRequired();
            builder.Property(P => P.Image).IsRequired();
            builder.Property(P => P.TrueInformation).HasMaxLength(5).IsRequired();
            builder.Property(P => P.TypeDamage).HasMaxLength(50).IsRequired();

            builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.DamageReport)
               .HasForeignKey(p => p.IdUser)
               .HasPrincipalKey(p => p.NationalIdentificationNumber);
        }
    }
}
