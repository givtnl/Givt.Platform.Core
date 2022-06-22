using Givt.Core.Domain.Entities.Base;
using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities;

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