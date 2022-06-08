using Givt.Domain.Enums;

namespace Givt.Domain.Interfaces;

public interface IHistory
{
    public DateTime Modified { get; set; }
    public LogReason Reason { get; set; }
}
public interface IHistory<Tid> : IHistory
{
    public Tid Id { get; set; }
}
