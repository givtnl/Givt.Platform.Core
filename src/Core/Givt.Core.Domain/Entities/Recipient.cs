using Givt.Platform.Payments.Enums;

namespace Givt.Core.Domain.Entities;

public class Recipient 
{
    public Guid OwnerId { get; set; } // also primary key
    public LegalEntity Owner { get; set; }
    public string DisplayName { get; set; }
    public string LogoImageLink { get; set; }
    public ICollection<FeeAgreement> FeeAgreements { get; set; }
    public ICollection<PaymentMethod> PaymentMethods { get; set; }
    public Guid PrimaryPayOutMethodId { get; set; }
    public PayOutMethod PrimaryPayOutMethod { get; set; }
    public ICollection<PayOutMethod> PayOutMethods { get; set; }
    public List<Authorisation> Members { get; set; }

    public Guid DefaultCampaignId { get; set; }
    /// <summary>
    /// The default campaign to allocate donations to, when the user has not selected a specific one
    /// </summary>
    public Campaign DefaultCampaign { get; set; }

    /// <summary>
    /// All Campaigns by this entity
    /// </summary>
    public ICollection<Campaign> Campaigns { get; set; }

    /// <summary>
    /// All timeslot(s) defined for this entity
    /// </summary>
    public ICollection<Timeslot> Timeslots { get; set; }

    /// <summary>
    /// All medium(s) defined for this entity
    /// </summary>
    public ICollection<Medium> Mediums { get; set; }
}