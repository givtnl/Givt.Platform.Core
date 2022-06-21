using Givt.Domain.Enums;

namespace Givt.Domain.Interfaces;

public interface IHistory
{
    public Guid Id { get; set; }
    public DateTime Modified { get; set; }
    public LogReason Reason { get; set; }
}