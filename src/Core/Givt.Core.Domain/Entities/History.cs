using Givt.Core.Domain.Enums;
using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities
{
    public abstract class History : IHistory
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }
        public LogReason Reason { get; set; }
    }
}