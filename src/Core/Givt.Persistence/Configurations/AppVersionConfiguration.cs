using Givt.Domain.Entities;
using Givt.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistence.Configurations;

public class AppVersionConfiguration : EntityBaseInt64Configuration<AppVersion>
{
    public override void Configure(EntityTypeBuilder<AppVersion> builder)
    {
        base.Configure(builder);
    }
}
