using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder
            .HasKey(e => e.EmailNormalised);

        builder
            .Property(e => e.Name)
            .HasMaxLength(50);
        builder
            .Property(e => e.Email)
            .HasMaxLength(200);
        builder
            .Property(e => e.EmailNormalised)
            .HasMaxLength(200);
    }
}
