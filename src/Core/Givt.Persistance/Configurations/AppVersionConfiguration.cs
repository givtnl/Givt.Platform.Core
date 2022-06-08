using Givt.Domain.Entities;
using Givt.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations;

public class AppVersionConfiguration : EntityBaseConfiguration<AppVersion>
{
    public override void Configure(EntityTypeBuilder<AppVersion> builder)
    {
        base.Configure(builder);
    }
}
