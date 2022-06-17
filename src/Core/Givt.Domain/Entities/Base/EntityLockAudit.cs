using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities.Base;

public abstract class EntityLockAudit<TId, Ttoken> : EntityAudit<TId>
{
    public Ttoken ConcurrencyToken { get; set; }
}