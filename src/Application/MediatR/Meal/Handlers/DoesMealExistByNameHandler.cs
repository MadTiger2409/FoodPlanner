using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class DoesMealExistByNameHandler : IRequestHandler<DoesMealExistByNameQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesMealExistByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesMealExistByNameQuery request, CancellationToken cancellationToken)
            => await _context.Meals.AnyAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));
    }
}