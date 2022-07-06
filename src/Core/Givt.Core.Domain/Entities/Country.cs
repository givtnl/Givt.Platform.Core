using Givt.Platform.Payments.Enums;

namespace Givt.Core.Domain.Entities;

public class Country
{
    public string Code { get; set; } // primary key
    public string Currency { get; set; }
    public Guid GivtOfficeId { get; set; }    
    public GivtOffice GivtOffice { get; set; } // Givt Office
    public ICollection<PaymentMethod> PaymentMethods { get; set; } // Payment methods used/allowed in this country     
}