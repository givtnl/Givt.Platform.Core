using AutoMapper;
using Givt.Core.Business.Extensions;
using Givt.Core.Business.Models;
using Givt.Core.Domain.Entities;
using Givt.Core.Persistence.DbContexts;
using Givt.Platform.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Givt.Core.Business.CQR;

public class CampaignGetHandler : IRequestHandler<CampaignGetQuery, Campaign>
{
    private readonly IMapper _mapper;
    private readonly CoreContext _context;

    public CampaignGetHandler(IMapper mapper, CoreContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Campaign> Handle(CampaignGetQuery request, CancellationToken cancellationToken)
    {
        var campaignId = Guid.Empty;
        if (request.CampaignId != Guid.Empty)
        {
            campaignId = request.CampaignId;
        }
        else
        {
            // query medium and check how it is linked to a campaign
            var medium = await _context.Mediums
                .Where(x => x.MediumId == request.MediumId.ToString())
                .Include(m => m.Timeslots)
                .Include(m => m.Owner) // Recipient
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);
            if (medium == null)
                throw new NotFoundException(nameof(request.MediumId), request.MediumId);

            campaignId = medium.GetActiveCampaignId();
            // database consistency check
            if (campaignId == Guid.Empty)
                throw new NotFoundException(nameof(Campaign), request.MediumId);
        }

        var now = DateTime.UtcNow;

        // fetch the campaign and related data
        IQueryable<Campaign> query = _context.Campaigns
            .Where(c => c.Id == campaignId)
            .Include(c => c.Owner) // Recipient
            .ThenInclude(r => r.Owner) // LegalEntity
            .ThenInclude(le => le.Country);
        if (request.IncludeTexts)
        {
            query = query
                .Include(c => c.Texts);
        }
        if (request.IncludeFees)
        {
            query = query
                .Include(c => c.FeeAgreements)
                .ThenInclude(fa => fa.Fee)
                .Include(c => c.DefaultFee);
        }
        // execute query
        var campaign = await query
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (request.IncludeFees && campaign != null)
        {
            // Select proper Fee. Do a selection in memory.
            // TODO: optimise loading of Fees (filter in the DB query)
            // TODO: discuss proper Fee selection criteria. Overlapping agreements etc.
            // TODO: does Fee depend on the amount given?
            campaign.FeeAgreements = campaign.FeeAgreements
                .Where(x =>
                        (x.StartDateTime == null || x.StartDateTime <= now) &&
                        (x.EndDateTime == null || x.EndDateTime >= now))
                .OrderByDescending(x => x.EndDateTime)
                .ThenByDescending(x => x.StartDateTime)
                .ToList();
        }
        return campaign;
    }
}
/*

    public async Task<Campaign> Handle(CampaignGetQuery request, CancellationToken cancellationToken)
    {
        var medium = await _context.Mediums
            .Where(x => x.MediumId == request.MediumId.ToString())
            .Include(m => m.Timeslots)
            .Include(m => m.Owner) // Recipient
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
        if (medium == null)
            throw new NotFoundException(nameof(request.MediumId), request.MediumId);

        var campaignId = medium.GetActiveCampaignId();

        // database consistency check
        if (campaignId == Guid.Empty)
            throw new NotFoundException(nameof(Campaign), request.MediumId);

        var now = DateTime.UtcNow;

        // fetch the campaign and related data
        var campaign = await _context.Campaigns
            .Where(c => c.Id == campaignId)
            .Include(c => c.Owner) // Recipient
            .ThenInclude(r => r.Owner) // LegalEntity
            .ThenInclude(le => le.Country)
            .Include(c => c.FeeAgreements)
            .ThenInclude(fa => fa.Fee)
            .Include(c => c.DefaultFee)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        // Select proper Fee. Do a selection in memory.
        // TODO: optimise this so it is done in the DB query
        campaign.FeeAgreements = campaign.FeeAgreements
            .Where(x =>
                    (x.StartDateTime == null || x.StartDateTime <= now) &&
                    (x.EndDateTime == null || x.EndDateTime >= now))
            .OrderByDescending(x => x.EndDateTime) // TODO: discuss proper selection criteria
            .ThenByDescending(x => x.StartDateTime)
            .Take(1)
            .ToList();
        return campaign;
        //// map to requested result
        //var result = _mapper.Map<MediumInfo>(medium);
        //// Add Campaign info
        //_mapper.Map(campaign, result);
        //return result;
    }
}*/