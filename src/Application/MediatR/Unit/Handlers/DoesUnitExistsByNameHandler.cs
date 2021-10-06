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
    public class DoesUnitExistsByNameHandler : IRequestHandler<DoesUnitExistsByNameQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesUnitExistsByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesUnitExistsByNameQuery request, CancellationToken cancellationToken)
            => await _context.Units.AnyAsync(x => x.Name.ToLowerInvariant().Equals(request.Name.ToLowerInvariant()));
    }
}