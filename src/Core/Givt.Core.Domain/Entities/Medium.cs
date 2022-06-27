using Givt.Core.Domain.Entities.Base;
using Givt.Core.Domain.Interfaces;

namespace Givt.Core.Domain.Entities;

public class Medium : EntityBase, IEntity
{
    /// <summary>
    /// Namespace + instance
    /// </summary>
    public string MediumId { get; set; }
    public Guid OwnerId { get; set; }
    public Recipient Owner { get; set; }


    public Guid CampaignId { get; set; }
    /// <summary>
    /// The Campaign this medium <b>always</b> relates to. If there is flexibility e.g. through Timeslot(s), this is not set.
    /// </summary> 
    public Campaign Campaign { get; set; } // TODO: discuss if this is needed. Can always link to an infinite timeslot?

    /// <summary>
    /// The Timeslot(s) in which this medium is valid. Through the TimeSlot the medium is linked to a Campaign.
    /// </summary>
    public ICollection<Timeslot> Timeslots { get; set; }
}