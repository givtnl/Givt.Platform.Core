﻿using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class PayOutConfiguration : EntityBaseInt64Configuration<PayOut>
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
