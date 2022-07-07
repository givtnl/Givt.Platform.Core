using Givt.Core.Business.Models;
using MediatR;

namespace Givt.Core.Business.CQR;

public class MediumExistQuery : IRequest<bool>
{
    public MediumIdType MediumIdType { get; set; }
}