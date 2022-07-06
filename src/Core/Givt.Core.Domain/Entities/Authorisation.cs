using Givt.Platform.Common.Enums;

namespace Givt.Core.Domain.Entities;

public class Authorisation
{
    public Guid UserId { get; set; }    
    public User User { get; set; }
    public Guid ResourceId { get; set; } // either Recipient or Donor ID
    public Recipient Recipient { get; set; }
    public Donor Donor { get; set; }
    public Role Role { get; set; }
}