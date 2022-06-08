using Givt.Domain.Entities.Base;

namespace Givt.Domain.Entities;

public class Timeslot : EntityBase<Guid>
{
    public Guid OwnerId { get; set; }
    public Recipient Owner { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public Guid CampaignId { get; set; }    
    public Campaign Campaign { get; set; }
    public Guid MediumId { get; set; }    
    public Medium Medium { get; set; }
}