using Givt.Core.Domain.Entities;

namespace Givt.Core.Business.Extensions;

public static class MediumExtensions
{
    public static Guid GetActiveCampaignId(this Medium medium)
    {
        // go through the data to find the correct Campaign

        // Does the medium have a hard link to a Campaign?
        var campaignId = medium.CampaignId;

        if (campaignId != Guid.Empty)
            return campaignId;

        // Is there time slot for this medium
        var now = DateTime.UtcNow;
        var ts = medium.Timeslots
            .Where(t => (t.StartDateTime == null || t.StartDateTime <= now) && (t.EndDateTime == null || t.EndDateTime >= now))
            .FirstOrDefault();
        // TODO: decide what to do when multiple timeslots fit
        if (ts != null)
            campaignId = ts.CampaignId;

        if (campaignId != Guid.Empty)
            return campaignId;

        // return the Default Campaign of the owner of the medium
        if (medium.Owner != null)
            campaignId = medium.Owner.DefaultCampaignId ?? Guid.Empty;

        return campaignId;
    }
}
