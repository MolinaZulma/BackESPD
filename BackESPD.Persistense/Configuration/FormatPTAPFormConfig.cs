using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackESPD.Persistense.Configuration
{
    public class FormatPTAPFormConfig : IEntityTypeConfiguration<FormatPTAPForm>
    {
        public void Configure(EntityTypeBuilder<FormatPTAPForm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable(nameof(FormatPTAPForm));
            builder.Property(P => P.Date);
            builder.Property(P => P.TypeWater);
            builder.Property(P => P.Temperature);
            builder.Property(P => P.AlkalinityPh);
            builder.Property(P => P.AlkalineChlorine);
            builder.Property(P => P.AlkalineInitialReading);
            builder.Property(P => P.AlkalineFinalReading);
            builder.Property(P => P.AlkalineTotal);
            builder.Property(P => P.Alkaline);
            builder.Property(P => P.ChlorineGas);
            builder.Property(P => P.ParticlesPerMillion);
            builder.Property(P => P.IdUser);
            builder.Property(P => P.IdPlant);



        }
    }
}
