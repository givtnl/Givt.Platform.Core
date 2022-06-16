namespace Givt.Domain.Entities.Base;

public abstract class EntityAudit<TId> : EntityBase<TId>
{
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}