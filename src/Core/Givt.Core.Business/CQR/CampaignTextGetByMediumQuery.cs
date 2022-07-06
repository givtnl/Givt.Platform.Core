using Givt.Core.Domain.Entities;
using MediatR;

namespace Givt.Core.Business.CQR;

public class CampaignTextGetByMediumQuery : IRequest<Campaign>
{
    public string MediumId { get; set; }
    public string Language { get; set; }
}