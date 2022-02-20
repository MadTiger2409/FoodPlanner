using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Common.ProjectionModels;
using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class GetPlannedMealsHandler : IRequestHandler<GetPlannedMealsQuery, List<PlannedMealsGroupModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlannedMealsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlannedMealsGroupModel>> Handle(GetPlannedMealsQuery request, CancellationToken cancellationToken)
        {
            var plannedMealsInGroups = await _context.PlannedMeals
                           .Where(x => x.ScheduledFor.Date >= request.From.Date && x.ScheduledFor.Date <= request.To.Date)
                           .Include(x => x.Meal).ThenInclude(y => y.Ingredients)
                           .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Product)
                           .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Unit)
                           .ToListAsync();

            return plannedMealsInGroups
                .GroupBy(x => x.ScheduledFor)
                .Select(y => new PlannedMealsGroupModel
                {
                    ScheduledFor = y.Key.Date,
                    PlannedMeals = _mapper.Map<List<PlannedMealForGroupingDto>>(y.Select(s => s))
                }).ToList();
        }
    }
}