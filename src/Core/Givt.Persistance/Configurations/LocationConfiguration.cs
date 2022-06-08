﻿using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class LocationConfiguration : EntityBaseConfiguration<Location>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        //base.Configure(builder); TODO: check/fix interference on Id with Medium

        builder
            .Property(e => e.Name)
            .HasMaxLength(50);
    }
}
