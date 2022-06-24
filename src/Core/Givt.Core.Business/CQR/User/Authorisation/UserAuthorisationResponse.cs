using Givt.Core.Domain.Enums;

namespace Givt.Core.Business.CQR.User.Authorisation;

public class UserAuthorisationResponse
{
    public Dictionary<Guid, Role> Memberships { get; set; }
}