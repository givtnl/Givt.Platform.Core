using Givt.Platform.EF.Entities;
using Givt.Platform.EF.Interfaces;

namespace Givt.Core.Domain.Entities;

public class PayOutMethod : EntityBase, IEntity
{
    public Guid RecipientId { get; set; }    
    public Recipient Recipient { get; set; }
    public string PSP_Owner { get; set; } // identifies the user at a payment service provider 
    public string PSP_Identification { get; set; } // ID that relates to a payment method at the payment service provider
}