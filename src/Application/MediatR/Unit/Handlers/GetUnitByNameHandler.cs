using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class GetUnitByNameHandler : IRequestHandler<GetUnitByNameQuery, Domain.Entities.Unit>
    {
        private readonly IApplicationDbContext _context;

        public GetUnitByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<Domain.Entities.Unit> Handle(GetUnitByNameQuery request, CancellationToken cancellationToken)
            => await _context.Units.SingleAsync(x => x.Name.ToLowerInvariant().Equals(request.Name.ToLowerInvariant()));
    }
}