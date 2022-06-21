using Givt.Domain.Entities;
using Givt.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations;

public class PayOutConfiguration : EntityBaseConfiguration<PayOut>
{
    public override void Configure(EntityTypeBuilder<PayOut> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.Currency)
            .HasMaxLength(3);

        builder
            .Property(e => e.PaymentProviderId)
            .HasMaxLength(100);

        builder
            .HasOne(e => e.Campaign)
            .WithMany(c => c.PayOuts)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
