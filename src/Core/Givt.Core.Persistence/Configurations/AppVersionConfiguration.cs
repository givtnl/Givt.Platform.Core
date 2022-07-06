using Givt.Core.Domain.Entities;
using Givt.Platform.EF.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Core.Persistence.Configurations;

public class AppVersionConfiguration : EntityBaseConfiguration<AppVersion>
{
    public override void Configure(EntityTypeBuilder<AppVersion> builder)
    {
        base.Configure(builder);
    }
}
