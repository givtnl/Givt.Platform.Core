using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities.Base;

public abstract class EntityAudit : EntityBase
{
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}