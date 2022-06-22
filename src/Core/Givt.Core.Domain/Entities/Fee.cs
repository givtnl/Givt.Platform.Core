using Givt.Core.Domain.Entities.Base;
using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities;

public class Fee : EntityBase, IEntity
{
    public string Name { get; set; }
    public string Currency { get; set; }
    public int Amount { get; set; }
    public int Percentage { get; set; }
}