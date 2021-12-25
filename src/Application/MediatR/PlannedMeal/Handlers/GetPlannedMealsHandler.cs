using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class GetPlannedMealsHandler : IRequestHandler<GetPlannedMealsQuery, List<Domain.Entities.PlannedMeal>>
    {
        private readonly IApplicationDbContext _context;

        public GetPlannedMealsHandler(IApplicationDbContext context) => _context = context;

        public async Task<List<Domain.Entities.PlannedMeal>> Handle(GetPlannedMealsQuery request, CancellationToken cancellationToken)
            => await _context.PlannedMeals
                        .Include(x => x.Meal).ThenInclude(y => y.Ingredients)
                        .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Product)
                        .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Unit).ToListAsync();
    }
}
