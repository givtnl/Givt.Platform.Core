using Givt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class AuthorisationConfiguration : IEntityTypeConfiguration<Authorisation>
{
    public void Configure(EntityTypeBuilder<Authorisation> builder)
    {
        builder
            .HasKey(e => new { e.UserId, e.ResourceId });
    }
}
