using Givt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations;

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
