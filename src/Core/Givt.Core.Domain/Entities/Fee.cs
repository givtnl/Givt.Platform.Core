using Givt.Platform.EF.Entities;
using Givt.Platform.EF.Interfaces;

namespace Givt.Core.Domain.Entities;

public class Fee : EntityBase, IEntity
{
    public string Name { get; set; }
    public string Currency { get; set; }
    public int Amount { get; set; }
    public int Percentage { get; set; }
}