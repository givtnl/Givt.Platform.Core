namespace Givt.Core.Domain.Entities;

public class CreditCard : PayInMethod
{
    public string Last4 { get; set; }
    public string Fingerprint { get; set; }
}