using Givt.Domain.Entities.Base;

namespace Givt.Domain.Entities;

/// <summary>
/// A transaction collecting a sum of donations from the donor
/// </summary>
public class PayIn : EntityBase<Int64>
{
    public DateTime EndDate { get; set; }
    public DateTime ExecutedDate { get; set; }
    public DateTime? PaymentProviderExecutionDate { get; set; }
    public string Currency { get; set; }
    public ICollection<Donation> Donations { get; set; }

    public Int64 PayInMethodId { get; set; }    
    public PayInMethod PayInMethod { get; set; }
        
    public int TotalPaid { get; set; }
}