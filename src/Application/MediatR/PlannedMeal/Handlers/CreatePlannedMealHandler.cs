using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.PlannedMeal.Commands;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class CreatePlannedMealHandler : IRequestHandler<CreatePlannedMealCommand, Domain.Entities.PlannedMeal>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public CreatePlannedMealHandler(IApplicationDbContext context, ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.PlannedMeal> Handle(CreatePlannedMealCommand request, CancellationToken cancellationToken)
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

            return plannedMeal;
        }
    }
}
