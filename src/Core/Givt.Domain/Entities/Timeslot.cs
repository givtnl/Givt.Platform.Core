using Givt.Domain.Entities.Base;

namespace Givt.Domain.Entities;

public class Timeslot : EntityBase<Int64>
{
    public Int64 OwnerId { get; set; }
    public Recipient Owner { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public Int64 CampaignId { get; set; }    
    public Campaign Campaign { get; set; }
    public Int64 MediumId { get; set; }    
    public Medium Medium { get; set; }
}