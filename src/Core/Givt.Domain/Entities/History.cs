using Givt.Domain.Enums;
using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities
{
    public abstract class History : IHistory
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }
        public LogReason Reason { get; set; }
    }
}