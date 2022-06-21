using Givt.Domain.Entities;
using Givt.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations;

public class LocationConfiguration : EntityBaseInt64Configuration<Location>
{
    public override void Configure(EntityTypeBuilder<Location> builder)
    {
        //base.Configure(builder); TODO: check/fix interference on Id with Medium

        builder
            .Property(e => e.Name)
            .HasMaxLength(50);
    }
}
