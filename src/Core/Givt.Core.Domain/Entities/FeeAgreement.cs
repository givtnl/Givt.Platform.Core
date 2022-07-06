using Givt.Platform.EF.Entities;
using Givt.Platform.EF.Interfaces;

namespace Givt.Core.Domain.Entities;

public class FeeAgreement: EntityBase, IEntity
{
    public Guid CampaignId { get; set; }    
    public Campaign Campaign { get; set; }
    public Guid RecipientId { get; set; }    
    public Recipient Recipient { get; set; }
    public Guid FeeId { get; set; }    
    public Fee Fee { get; set; }
    public int? MinVolumeCount { get; set; } // minimum volume discount start
    public string Currency { get; set; }
    public int? MinVolumeAmount { get; set; } // minimum amount discount start
    public int Discount { get; set; } // percentage
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
}