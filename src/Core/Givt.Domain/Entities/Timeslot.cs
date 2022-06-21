using Givt.Domain.Entities.Base;
using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities;

public class Timeslot : EntityBase, IEntity
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