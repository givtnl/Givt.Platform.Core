using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities.Base;

public abstract class EntityBase<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}