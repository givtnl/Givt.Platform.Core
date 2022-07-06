using Givt.Core.Business.CQR;
using Givt.Core.Business.Models;
using Givt.Core.Domain.Entities;
using MediatR;

namespace Givt.Core.Business.Infrastructure.Pipelines;

public class CampaignTextGetPipeline<TRequest, TResponse> : IRequestHandler<TRequest, Campaign>
       where TRequest : CampaignTextGetByMediumQuery
{
    private readonly IRequestHandler<TRequest, Campaign> _inner;

    public CampaignTextGetPipeline(
        IRequestHandler<TRequest, Campaign> inner)
    {
        _inner = inner;
    }

    public async Task<Campaign> Handle(TRequest request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Language))
            request.Language = "en";
        else
        {
            // clean up language/locale passed from client
            /* Routine to get a language from the API front, and normalise it to a IETF standard value
             * IETF BCP 47 language tag: en-GB (https://en.wikipedia.org/wiki/IETF_language_tag
             * Http Headers a.o.: en_GB https://en.wikipedia.org/wiki/Locale_(computer_software)
             */
            request.Language = request.Language.Trim().Replace('_', '-');
        }

        var result = await _inner.Handle(request, cancellationToken);
        
        return result;
    }
}
