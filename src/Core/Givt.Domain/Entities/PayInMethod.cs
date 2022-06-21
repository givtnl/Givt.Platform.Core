using Givt.Domain.Entities.Base;
using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities;

public abstract class PayInMethod : EntityBase<Int64>, IEntity<Int64>
{
    public Int64 OwnerId { get; set; }    
    public Donor Owner { get; set; }
    public string PSP_Owner { get; set; } // identifies the user at a payment service provider 
    public string PSP_Identification { get; set; } // ID that relates to a payment method at the payment service provider

}