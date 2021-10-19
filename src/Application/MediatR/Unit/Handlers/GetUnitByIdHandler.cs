using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class GetUnitByIdHandler : IRequestHandler<GetUnitByIdQuery, Domain.Entities.Unit>
    {
        private readonly IApplicationDbContext _context;

        public GetUnitByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<Domain.Entities.Unit> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var unit = await _context.Units.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (unit == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return unit;
        }
    }
}