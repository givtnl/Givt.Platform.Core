using MediatR;

namespace Givt.Core.Business.CQR;

public class UserAuthorisationQuery : IRequest<UserAuthorisationResponse>
{
    public string Email { get; set; }
}
