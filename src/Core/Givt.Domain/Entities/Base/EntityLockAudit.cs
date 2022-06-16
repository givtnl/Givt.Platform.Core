using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities.Base;

public abstract class EntityLockAudit<TId, Ttoken> : EntityAudit<TId>, IOptimisticLock<Ttoken>
{
    public Ttoken ConcurrencyToken { get; set; }
}