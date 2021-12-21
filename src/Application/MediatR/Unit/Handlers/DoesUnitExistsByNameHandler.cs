using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class DoesUnitExistsByNameHandler : IRequestHandler<DoesUnitExistByNameQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesUnitExistsByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesUnitExistByNameQuery request, CancellationToken cancellationToken)
            => await _context.Units.AnyAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));
    }
}