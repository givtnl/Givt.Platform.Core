using Givt.Core.Business.CQR;
using Givt.Core.Domain.Entities;
using MediatR;
using System.Net.Http.Headers;

namespace Givt.Core.API.Pipelines;

public class CampaignGetPipeline<TRequest, TResponse> : IRequestHandler<TRequest, Campaign>
       where TRequest : CampaignGetQuery
{
    private readonly IRequestHandler<TRequest, Campaign> _inner;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CampaignGetPipeline(
        IRequestHandler<TRequest, Campaign> inner,
        IHttpContextAccessor httpContextAccessor)
    {
        _inner = inner;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Campaign> Handle(TRequest request, CancellationToken cancellationToken)
    {
        // get requested languages from HTTP Context
        string header = _httpContextAccessor.HttpContext.Request.Headers.AcceptLanguage;
        if (request.Languages?.Count > 0)
            header = String.Join(",", request.Languages) + ',' + header;

        // select language/region codes in (descending) order of quality, and clean up language/locale passed from client
        /* Routine to get a language from the API front, and normalise it to a IETF standard value
         * IETF BCP 47 language tag: en-GB (https://en.wikipedia.org/wiki/IETF_language_tag
         * Http Headers a.o.: en_GB https://en.wikipedia.org/wiki/Locale_(computer_software)
         */
        request.Languages = header.Split(',')
            .Select(StringWithQualityHeaderValue.Parse)
            .Distinct()
            .OrderByDescending(s => s.Quality.GetValueOrDefault(1))
            .Select(vq => vq.Value.Trim().Replace('_', '-'))
            .ToList();

        // process rest of pipeline
        return await _inner.Handle(request, cancellationToken);
    }
}