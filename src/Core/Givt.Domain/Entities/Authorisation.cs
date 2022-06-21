using Givt.Domain.Enums;

namespace Givt.Domain.Entities;

public class Authorisation
{
    public Int64 UserId { get; set; }    
    public User User { get; set; }
    public Int64 ResourceId { get; set; } // either Recipient or Donor ID
    public Recipient Recipient { get; set; }
    public Donor Donor { get; set; }
    public Role Role { get; set; }
}