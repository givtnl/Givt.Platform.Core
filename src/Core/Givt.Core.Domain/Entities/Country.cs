using Givt.Core.Domain.Enums;

namespace Givt.Core.Domain.Entities;

public class Country
{
    public string Code { get; set; } // primary key
    public string Currency { get; set; }
    public Guid GivtOfficeId { get; set; }    
    public LegalEntity GivtOffice { get; set; } // Givt Office
    public IEnumerable<PaymentMethod> PaymentMethods { get; set; } // Payment methods used/allowed in this country     
}