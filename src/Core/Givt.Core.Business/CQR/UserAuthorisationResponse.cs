using Givt.Platform.Common.Enums;

namespace Givt.Core.Business.CQR;

public class UserAuthorisationResponse
{
    public Dictionary<Guid, Role> Memberships { get; set; }
}