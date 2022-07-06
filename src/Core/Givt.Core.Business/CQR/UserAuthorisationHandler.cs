using Givt.Core.Persistence.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Givt.Core.Business.CQR;

public class UserAuthorisationHandler : IRequestHandler<UserAuthorisationQuery, UserAuthorisationResponse>
{
    private readonly CoreContext _context;

    public UserAuthorisationHandler(CoreContext context)
    {
        _context = context;
    }

    public async Task<UserAuthorisationResponse> Handle(UserAuthorisationQuery request, CancellationToken cancellationToken)
    {
        var roles = await _context.Authorisations
            .Where(e => e.User.EmailNormalised == Domain.Entities.User.NormaliseEmail(request.Email))
            .Select(e => new { e.ResourceId, e.Role })
            .AsNoTracking()
            .ToDictionaryAsync(s => s.ResourceId, s => s.Role, cancellationToken: cancellationToken);

        return new UserAuthorisationResponse { Memberships = roles };
    }
}
