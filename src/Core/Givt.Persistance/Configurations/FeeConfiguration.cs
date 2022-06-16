using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class FeeConfiguration : EntityBaseInt64Configuration<Fee>
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
