using Givt.Core.Persistence.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Givt.Core.Business.CQR;

public class MediumExistHandler : IRequestHandler<MediumExistQuery, bool>
{
    private readonly CoreContext _context;

    public MediumExistHandler(CoreContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(MediumExistQuery request, CancellationToken cancellationToken)
    {
        return await _context.Mediums
            .AnyAsync(x => x.MediumId == request.MediumIdType, cancellationToken);
    }
}