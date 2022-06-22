namespace Givt.Core.Domain.Entities.Base;

public abstract class EntityLockAudit<Ttoken> : EntityAudit
{
    public Ttoken ConcurrencyToken { get; set; }
}
