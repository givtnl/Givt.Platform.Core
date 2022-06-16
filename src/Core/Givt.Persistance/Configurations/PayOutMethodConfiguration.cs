﻿using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class PayOutMethodConfiguration : EntityBaseInt64Configuration<PayOutMethod>
{
    public override void Configure(EntityTypeBuilder<PayOutMethod> builder)
    {
        base.Configure(builder);

        builder
            .Property(e => e.PSP_Owner)
            .HasMaxLength(100);
        builder
            .Property(e => e.PSP_Identification)
            .HasMaxLength(100);

        builder
            .HasOne(e => e.Recipient)
            .WithMany(r => r.PayOutMethods)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
