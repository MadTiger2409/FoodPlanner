using Application.Common.Interfaces;
using Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.MediatR.Unit.Handlers
{
    public class GetUnitByNameHandler : IRequestHandler<GetUnitByNameQuery, Domain.Entities.Unit>
    {
        private readonly IApplicationDbContext _context;

        public GetUnitByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<Domain.Entities.Unit> Handle(GetUnitByNameQuery request, CancellationToken cancellationToken)
            => await _context.Units.SingleOrDefaultAsync(x => x.Name.ToLowerInvariant().Equals(request.Name.ToLowerInvariant()));
    }
}