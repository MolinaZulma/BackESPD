using BackESPD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackESPD.Persistense.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           builder.Property(P => P.NationalIdentificationNumber).HasMaxLength(15).IsRequired();
           builder.Property(P => P.FullName).HasMaxLength(300).IsRequired();

        }
    }
}
