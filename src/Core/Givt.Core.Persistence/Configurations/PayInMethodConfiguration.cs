using Givt.Core.Domain.Entities;
using Givt.Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class PayInMethodConfiguration : EntityBaseConfiguration<PayInMethod>
{
    public override void Configure(EntityTypeBuilder<PayInMethod> builder)
    {
        base.Configure(builder);

        // configure Table per Hierarchy strategy
        builder
            .HasDiscriminator<int>("Class")
            .HasValue<PayInMethod>(0)
            .HasValue<CreditCard>(1);

        builder
            .Property(e => e.PSP_Owner)
            .HasMaxLength(100);
        builder
            .Property(e => e.PSP_Identification)
            .HasMaxLength(100);

        builder
            .HasOne(e => e.Owner)
            .WithMany(o => o.PayInMethods)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
