using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class ActivityLogsFormConfig : IEntityTypeConfiguration<ActivityLogsForm>
    {
        public void Configure(EntityTypeBuilder<ActivityLogsForm> builder)
        {
           builder.HasKey(x => x.Id);
           builder.ToTable(nameof(ActivityLogsForm));
           builder.Property(P => P.TypeActivity).HasMaxLength(300).IsRequired();
           builder.Property(P => P.Observations).HasMaxLength(300).IsRequired();

           builder.HasOne(p => p.IdUserNavigation).WithMany(p => p.ActivityLogsForm)
               .HasForeignKey(p => p.NationalIdentificationNumber)
               .HasPrincipalKey(p => p.NationalIdentificationNumber);

          builder.HasOne(p => p.IdPlantNavigation).WithMany(p => p.ActivityLogsForm)
               .HasForeignKey(p => p.IdPlant)
               .HasPrincipalKey(p => p.Id);
        }
    }
}

