using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class GetPlannedMealByIdHandler : IRequestHandler<GetPlannedMealByIdQuery, PlannedMealDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlannedMealByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlannedMealDto> Handle(GetPlannedMealByIdQuery request, CancellationToken cancellationToken)
        {
            var plannedMeal = await _context.PlannedMeals
                .Include(x => x.Meal).ThenInclude(y => y.Ingredients)
                .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Product)
                .Include(x => x.Meal.Ingredients).ThenInclude(y => y.Unit)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (plannedMeal == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return _mapper.Map<PlannedMealDto>(plannedMeal);
        }
    }
}
