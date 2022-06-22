using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities.Base;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; }
}