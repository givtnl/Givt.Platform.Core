using Givt.Domain.Entities;
using Givt.Persistence.Configurations.Base;
using Givt.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations;

public class CampaignConfiguration : EntityBaseConfiguration<Campaign>
{
    public override void Configure(EntityTypeBuilder<Campaign> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.Namespace)
            .HasMaxLength(33);

        builder
            .Property(e => e.Amounts)
            .HasConversion(AmountsConverter.GetConverter())
            .HasMaxLength(50)
            .Metadata.SetValueComparer(AmountsConverter.GetComparer());

        builder
            .HasOne(e => e.DefaultFee)
            .WithMany()
            .HasForeignKey(e => e.DefaultFeeId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.PayOutMethod)
            .WithMany()
            .HasForeignKey(e => e.PayOutMethodId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Restrict);

    }

}
