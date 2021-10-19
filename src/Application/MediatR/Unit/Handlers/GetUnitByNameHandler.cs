using FoodPlanner.Application.Common.Exceptions;
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
        {
            var unit = await _context.Units.SingleOrDefaultAsync(x => x.Name.ToLowerInvariant().Equals(request.Name.ToLowerInvariant()));

            if (unit == null)
                throw new EntityNotFoundException(nameof(request.Name));

            return unit;
        }
    }
}