using Givt.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Givt.Persistance.Configurations.Base
{
    public class OptimisticLockConfiguration<TEntity> : EntityBaseConfiguration<TEntity>
        where TEntity : EntityLockAudit<Guid, DateTime>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            // override property default settings
            builder
                .Property(e => e.ConcurrencyToken)
                .IsRowVersion();
        }
    }

}
