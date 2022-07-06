using Givt.Core.Domain.Entities;
using Givt.Platform.EF.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class FeeConfiguration : EntityBaseConfiguration<Fee>
{
    public override void Configure(EntityTypeBuilder<Fee> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.Name)
            .HasMaxLength(50);
        builder
            .Property(e => e.Currency)
            .HasMaxLength(3);
    }
}
