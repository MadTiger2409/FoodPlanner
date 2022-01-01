using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using FoodPlanner.Application.MediatR.PlannedMeal.Commands;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class CreatePlannedMealHandler : IRequestHandler<CreatePlannedMealCommand, PlannedMealDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreatePlannedMealHandler(IApplicationDbContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PlannedMealDto> Handle(CreatePlannedMealCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CanCreatePlannedMealQuery(request.MealId, request.OrdinalNumber, request.ScheduledFor));

            var plannedMeal = new Domain.Entities.PlannedMeal
            {
                MealId = request.MealId,
                OrdinalNumber = request.OrdinalNumber,
                ScheduledFor = request.ScheduledFor.Date
            };

            _context.PlannedMeals.Add(plannedMeal);
            await _context.SaveChangesAsync();

            return _mapper.Map<PlannedMealDto>(plannedMeal);
        }
    }
}
