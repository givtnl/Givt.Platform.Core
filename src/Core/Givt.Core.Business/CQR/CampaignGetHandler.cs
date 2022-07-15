using AutoMapper;
using Givt.Core.Business.Extensions;
using Givt.Core.Domain.Entities;
using Givt.Core.Persistence.DbContexts;
using Givt.Platform.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
            var mediumQuery = (IQueryable<Medium>)_context.Mediums;
            if (request.MediumId == Guid.Empty)
                mediumQuery = mediumQuery.Where(x => x.MediumId == (string)request.MediumIdType);
            else
                mediumQuery = mediumQuery.Where(x => x.Id == request.MediumId);
            var medium = await mediumQuery
                .Include(m => m.Timeslots)
                .Include(m => m.Owner) // Recipient
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);
            if (medium == null)
            {
                if (request.MediumId == Guid.Empty)
                    throw new NotFoundException(nameof(request.MediumIdType), request.MediumIdType);
                else
                    throw new NotFoundException(nameof(request.MediumId), request.MediumId);
            }

            campaignId = medium.GetActiveCampaignId();
            // database consistency check
            if (campaignId == Guid.Empty)
                throw new NotFoundException(nameof(Campaign), request.MediumId);
        }

        IQueryable<Campaign> query;
        // fetch the campaign and related data
        var countryQuery = _context.Campaigns // IIncludableQueryable<Campaign, Country> 
            .Where(c => c.Id == campaignId)
            .Include(c => c.Owner) // Recipient
            .ThenInclude(r => r.Owner) // LegalEntity
            .ThenInclude(le => le.Country);
        if (request.IncludeGivtOffice)
            query = countryQuery
                .ThenInclude(c => c.GivtOffice);
        else
            query = countryQuery;
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
        //if (request.IncludePaymentProviders)
        //{
        //    query = query.Include(c => c.????);  // TODO: design this
        //}

        // execute query
        var campaign = await query
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        if (request.IncludeFees && campaign != null)
        {
            var now = DateTime.UtcNow;

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