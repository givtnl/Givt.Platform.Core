namespace Givt.Domain.Entities;

public class Donor 
{
    public Guid OwnerId { get; set; } // also primary key
    public LegalEntity Owner { get; set; }

    public IEnumerable<Donation> Donations { get; set; }

    public Guid PrimaryPayInMethodId { get; set; }    
    public PayInMethod PrimaryPayInMethod { get; set; }
    public ICollection<PayInMethod> PayInMethods { get; set; }

    public ICollection<PayIn> PayIns { get; set; }
    
    // UI
    public string Language { get; set; }
    public string TimeZoneId { get; set; }
}