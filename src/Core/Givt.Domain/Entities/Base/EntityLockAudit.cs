using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities.Base;

public abstract class EntityLockAudit<TId, Ttoken> : EntityBase<TId>, IOptimisticLock<Ttoken>
{
    public Ttoken ConcurrencyToken { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}