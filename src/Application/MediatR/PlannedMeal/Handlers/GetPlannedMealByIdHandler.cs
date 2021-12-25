using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class GetPlannedMealByIdHandler : IRequestHandler<GetPlannedMealByIdQuery, Domain.Entities.PlannedMeal>
    {
        private readonly IApplicationDbContext _context;

        public GetPlannedMealByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<Domain.Entities.PlannedMeal> Handle(GetPlannedMealByIdQuery request, CancellationToken cancellationToken)
        {
            var plannedMeal = await _context.PlannedMeals
                                        .Include(x => x.Meal).ThenInclude(y => y.Ingredients)
                                        .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Product)
                                        .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Unit)
                                        .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (plannedMeal == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return plannedMeal;
        }
    }
}
