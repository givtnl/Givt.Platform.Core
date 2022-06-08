using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class FeeAgreementConfiguration : EntityBaseConfiguration<FeeAgreement>
{
    public override void Configure(EntityTypeBuilder<FeeAgreement> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.Currency)
            .HasMaxLength(3);

        builder
            .HasOne(e => e.Fee)
            .WithMany()
            .HasForeignKey(e => e.FeeId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
