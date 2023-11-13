using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.HasAlternateKey(P => P.NationalIdentificationNumber);
           builder.Property(P => P.FullName).HasMaxLength(300).IsRequired();

        }
    }
}
