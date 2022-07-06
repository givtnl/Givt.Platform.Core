using Givt.Core.Domain.Entities;
using MediatR;

namespace Givt.Core.Business.CQR;

public class CampaignGetByMediumQuery : IRequest<Campaign>
{
    public string MediumId { get; set; }
}