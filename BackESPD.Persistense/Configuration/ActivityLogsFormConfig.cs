using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackESPD.Persistense.Configuration
{
    public class ActivityLogsFormConfig : IEntityTypeConfiguration<ActivityLogsForm>
    {
        public void Configure(EntityTypeBuilder<ActivityLogsForm> builder)
        {
           builder.HasKey(x => x.Id);
           builder.ToTable(nameof(ActivityLogsForm));
           builder.Property(P => P.Date);
           builder.Property(P => P.TypeActivity).HasMaxLength(300);
           builder.Property(P => P.Observations).HasMaxLength(300);
           builder.Property(P => P.IdUser);
           builder.Property(P => P.IdPlant);
        }
    }
}
