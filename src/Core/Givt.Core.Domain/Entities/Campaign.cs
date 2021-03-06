using Givt.Platform.EF.Entities;
using Givt.Platform.EF.Interfaces;

namespace Givt.Core.Domain.Entities;

public class Campaign : EntityBase, IEntity
{
    public Guid OwnerId { get; set; }
    public Recipient Owner { get; set; }
    public string Namespace { get; set; }
    public decimal[] Amounts { get; set; }

    public ICollection<Medium> Mediums { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ICollection<Timeslot> Timeslots { get; set; }
    public ICollection<CampaignTexts> Texts { get; set; }
    public Guid DefaultFeeId { get; set; }
    public Fee DefaultFee { get; set; }
    public ICollection<FeeAgreement> FeeAgreements { get; set; }
    public Guid PayOutMethodId { get; set; }
    public PayOutMethod PayOutMethod { get; set; }        
}