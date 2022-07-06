using Givt.Platform.EF.Enums;
using Givt.Platform.EF.Interfaces;

namespace Givt.Core.Domain.Entities
{
    public abstract class History : IHistory
    {
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }
        public EntityLogReason Reason { get; set; }
    }
}