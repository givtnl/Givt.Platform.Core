using Givt.Domain.Entities.Base;
using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities;

public class Donation : EntityAudit<Int64>, IDonation, IEntity<Int64>, IAuditBasic, ILoggedEntity
{
    public Int64 MediumId { get; set; }
    public Medium Medium { get; set; }
    public Int64 DonorId { get; set; }
    public Donor Donor { get; set; }
    public Int64 RecipientId { get; set; }
    public Recipient Recipient { get; set; }
    public Int64 CampaignId { get; set; }
    public Campaign Campaign { get; set; }
    public string Currency { get; set; }
    public int Amount { get; set; }
    public DateTime DonationDateTime { get; set; }
    public string TransactionReference { get; set; }
    public Int64 PayinId { get; set; }
    public PayIn Payin { get; set; }
    public string Last4 { get; set; }
    public string Fingerprint { get; set; }

    public Type HistoryEntityType => typeof(DonationHistory);
}
