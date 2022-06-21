using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities.Base;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; }
}