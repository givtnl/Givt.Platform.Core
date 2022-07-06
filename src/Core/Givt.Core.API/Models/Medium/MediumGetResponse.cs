namespace Givt.Core.API.Models.Medium;

public class MediumGetResponse
{    
    public Guid CampaignId { get; set; }
    public Guid RecipientId { get; set; }
    public string Country { get; set; }
    public string Currency { get; set; }
    public int FeeAmount { get; set; }
    public int FeePercentage { get; set; }

}