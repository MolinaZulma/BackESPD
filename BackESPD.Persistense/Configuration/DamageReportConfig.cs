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
            builder.Property(P => P.Name).HasMaxLength(50).IsRequired();
            builder.Property(P => P.AddressDamage).HasMaxLength(50).IsRequired();
            builder.Property(P => P.DescriptionDamage).HasMaxLength(100).IsRequired();
            builder.Property(P => P.Image).IsRequired();
            builder.Property(P => P.TrueInformation).HasMaxLength(5).IsRequired();
            builder.Property(P => P.TypeDamage).HasMaxLength(50).IsRequired();
        }
    }
}
