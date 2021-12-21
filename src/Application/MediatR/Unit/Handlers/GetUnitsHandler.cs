using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class GetUnitsHandler : IRequestHandler<GetUnitsQuery, IList<Domain.Entities.Unit>>
    {
        private readonly IApplicationDbContext _context;

        public GetUnitsHandler(IApplicationDbContext context) => _context = context;

        public async Task<IList<Domain.Entities.Unit>> Handle(GetUnitsQuery request, CancellationToken cancellationToken)
            => await _context.Units.ToListAsync();
    }
}