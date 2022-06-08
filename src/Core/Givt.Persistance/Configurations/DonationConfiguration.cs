using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class DonationConfiguration : OptimisticLockConfiguration<Donation>
{
    public override void Configure(EntityTypeBuilder<Donation> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.Currency)
            .HasMaxLength(3);

        builder
            .Property(e => e.TransactionReference)
            .HasMaxLength(50); // Stripe seems to use 27 characters

        builder
            .Property(e => e.Last4)
            .HasMaxLength(20);
        builder
            .Property(e => e.Fingerprint)
            .HasMaxLength(20);

        builder
            .HasOne(e => e.Donor)
            .WithMany(d => d.Donations)
            .IsRequired(false);

        builder
            .HasIndex(e => e.TransactionReference);
    }
}
