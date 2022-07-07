using Givt.Core.Business.Models;
using Givt.Core.Domain.Entities;
using MediatR;

namespace Givt.Core.Business.CQR;

public class CampaignGetQuery : IRequest<Campaign>
{
    public Guid CampaignId;
    public MediumIdType MediumIdType;
    public Guid MediumId;
    public ICollection<string> Languages;
    public bool IncludeTexts;
    public bool IncludeFees;
}