using Givt.Core.Domain.Entities;
using Givt.Core.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class AppVersionConfiguration : EntityBaseConfiguration<AppVersion>
{
    public override void Configure(EntityTypeBuilder<AppVersion> builder)
    {
        base.Configure(builder);
    }
}
