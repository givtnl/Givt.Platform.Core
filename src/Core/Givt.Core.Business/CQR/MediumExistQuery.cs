using MediatR;

namespace Givt.Core.Business.CQR;

public class MediumExistQuery : IRequest<bool>
{
    public string MediumId { get; set; }
}