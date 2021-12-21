using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class CanUpdateIngredientHandler : IRequestHandler<CanUpdateIngredientQuery>
    {
        private readonly ISender _mediator;

        public CanUpdateIngredientHandler(ISender mediator) => _mediator = mediator;

        public async Task<global::MediatR.Unit> Handle(CanUpdateIngredientQuery request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesIngredientExistByIdQuery(request.IngredientId)) == false)
                throw new EntityNotFoundException(nameof(request.IngredientId));

            if (await _mediator.Send(new DoesMealExistByIdQuery(request.MealId)) == false)
                throw new EntityNotFoundException(nameof(request.MealId));

            /*TODO
                Check if ingredient is in relationship with given meal
                Check if product exists
                Check if unit exists
                For each check create Mediator query and handler
             */

            return global::MediatR.Unit.Value;
        }
    }
}