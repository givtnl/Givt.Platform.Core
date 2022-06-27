using MediatR;

namespace Givt.Core.Business.CQR.User.Authorisation;

public class UserAuthorisationQuery: IRequest<UserAuthorisationResponse>
{
    public string Email { get; set; }
}
