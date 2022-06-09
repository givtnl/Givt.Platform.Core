using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class DonationHistoryConfiguration : IEntityTypeConfiguration<DonationHistory>
{
    public void Configure(EntityTypeBuilder<DonationHistory> builder)
    {
        builder
            .HasKey(e => new { e.Id, e.Modified });

        builder
            .Property(e => e.MediumId)
            .HasColumnType(Consts.GUID_COLUMN_TYPE);

        builder
            .Ignore(e => e.Medium);

        builder
            .Property(e => e.DonorId)
            .HasColumnType(Consts.GUID_COLUMN_TYPE);

        builder
            .Ignore(e => e.Donor);

        builder.Property(e => e.RecipientId)
            .HasColumnType(Consts.GUID_COLUMN_TYPE);

        builder
            .Ignore(e => e.Recipient);

        builder
            .Property(e => e.CampaignId)
            .HasColumnType(Consts.GUID_COLUMN_TYPE);

        builder
            .Ignore(e => e.Campaign);

        builder
            .Property(e => e.Currency)
            .HasMaxLength(3);

        builder
            .Property(e => e.TransactionReference)
            .HasMaxLength(50); // Stripe seems to use 27 characters

        builder
            .Property(e => e.PayinId)
            .HasColumnType(Consts.GUID_COLUMN_TYPE);

        builder.Ignore(e => e.Payin);

        builder
            .Property(e => e.Last4)
            .HasMaxLength(20);
        builder
            .Property(e => e.Fingerprint)
            .HasMaxLength(20);

        builder
            .HasIndex(e => e.TransactionReference);
    }
}
