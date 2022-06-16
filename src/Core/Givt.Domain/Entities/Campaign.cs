using Givt.Domain.Entities.Base;

namespace Givt.Domain.Entities;

public class Campaign : EntityBase<Int64>
{
    public Int64 OwnerId { get; set; }
    public Recipient Owner { get; set; }
    public string Namespace { get; set; }
    public decimal[] Amounts { get; set; }

    public ICollection<Medium> Mediums { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ICollection<Timeslot> Timeslots { get; set; }
    public ICollection<CampaignTexts> Texts { get; set; }
    public Int64 DefaultFeeId { get; set; }
    public Fee DefaultFee { get; set; }
    public ICollection<FeeAgreement> FeeAgreements { get; set; }
    public Int64 PayOutMethodId { get; set; }
    public PayOutMethod PayOutMethod { get; set; }
    
    public ICollection<PayOut> PayOuts{ get; set; }
}