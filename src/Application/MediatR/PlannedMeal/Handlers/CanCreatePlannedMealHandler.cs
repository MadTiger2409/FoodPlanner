using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.MediatR.Meal.Queries;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class CanCreatePlannedMealHandler : IRequestHandler<CanCreatePlannedMealQuery>
    {
        private readonly ISender _mediator;

        public CanCreatePlannedMealHandler(ISender mediator) => _mediator = mediator;

        public async Task Handle(CanCreatePlannedMealQuery request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesMealExistByIdQuery(request.MealId)) == false)
                throw new EntityNotFoundException(nameof(request.MealId));

            if (request.ScheduledFor.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Can't schedule meal for day from the past.");

            if (await _mediator.Send(new DoesPlannedMealExistByDateAndOrdinalNumberQuery(request.ScheduledFor, request.OrdinalNumber)))
                throw new ArgumentException($"There is already meal with ordinal number {request.OrdinalNumber} planned for {request.ScheduledFor.Date}");
        }
    }
}
