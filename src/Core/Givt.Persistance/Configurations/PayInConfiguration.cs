using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class PayInConfiguration : EntityBaseInt64Configuration<PayIn>
{
    public override void Configure(EntityTypeBuilder<PayIn> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.Currency)
            .HasMaxLength(3);

        builder
            .HasMany(e => e.Donations)
            .WithOne(d => d.Payin)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(e => e.PayInMethod)
            .WithMany()
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
