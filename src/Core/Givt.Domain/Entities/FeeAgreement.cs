using Givt.Domain.Entities.Base;

namespace Givt.Domain.Entities;

public class FeeAgreement: EntityBase<Int64>
{
    public Int64 CampaignId { get; set; }    
    public Campaign Campaign { get; set; }
    public Int64 RecipientId { get; set; }    
    public Recipient Recipient { get; set; }
    public Int64 FeeId { get; set; }    
    public Fee Fee { get; set; }
    public int? MinVolumeCount { get; set; } // minimum volume discount start
    public string Currency { get; set; }
    public int? MinVolumeAmount { get; set; } // minimum amount discount start
    public int Discount { get; set; } // percentage
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}