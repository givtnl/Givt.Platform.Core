using Givt.Core.Business.Models;
using Givt.Core.Domain.Entities;
using MediatR;

namespace Givt.Core.Business.CQR;

public class CampaignGetQuery : IRequest<Campaign>
{
    public Guid CampaignId;
    public MediumIdType MediumIdType;
    public Guid MediumId;
    public bool IncludeTexts;
    public bool IncludeFees;
    public bool IncludePaymentProviders;
    public bool IncludeGivtOffice;
}