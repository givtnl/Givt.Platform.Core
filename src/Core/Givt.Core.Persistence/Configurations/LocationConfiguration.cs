using Givt.Core.Domain.Entities;
using Givt.Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

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
