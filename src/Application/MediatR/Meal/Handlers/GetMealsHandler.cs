using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class GetMealsHandler : IRequestHandler<GetMealsQuery, IList<Domain.Entities.Meal>>
    {
        private readonly IApplicationDbContext _context;

        public GetMealsHandler(IApplicationDbContext context) => _context = context;

        public async Task<IList<Domain.Entities.Meal>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
            => await _context.Meals
                        .Include(x => x.Ingredients).ThenInclude(y => y.Product)
                        .Include(x => x.Ingredients).ThenInclude(y => y.Unit).ToListAsync();
    }
}