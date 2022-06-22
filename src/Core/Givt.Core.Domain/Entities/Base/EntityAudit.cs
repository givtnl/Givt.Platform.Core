using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities.Base;

public abstract class EntityAudit : EntityBase
{
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}