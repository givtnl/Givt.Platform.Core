using Givt.Domain.Entities.Base;
using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities;

public class Fee : EntityBase<Int64>, IEntity<Int64>
{
    public string Name { get; set; }
    public string Currency { get; set; }
    public int Amount { get; set; }
    public int Percentage { get; set; }
}