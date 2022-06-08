namespace Givt.Domain.Entities;

public class CampaignTexts
{
    public string LanguageId { get; set; }
    public Guid CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public string Title { get; set; }
    public string Goal { get; set; }
    public string ThankYou { get; set; }
}