using Givt.Core.Domain.Enums;

namespace Givt.Core.Domain.Entities;

public class User
{
    public string Name { get; set; }

    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            EmailNormalised = value.ToLower();
        } 
    }
    public string EmailNormalised { get; set; } // is key
    public ICollection<Authorisation> Authorisations { get; set; }
    public DeviceOS OS { get; set; }

}