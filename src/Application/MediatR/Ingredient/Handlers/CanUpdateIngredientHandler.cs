using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using FoodPlanner.Application.MediatR.Meal.Queries;
using FoodPlanner.Application.MediatR.Product.Queries;
using FoodPlanner.Application.MediatR.Unit.Queries;
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

        public async Task Handle(CanUpdateIngredientQuery request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesIngredientExistByIdQuery(request.IngredientId)) == false)
                throw new EntityNotFoundException(nameof(request.IngredientId));

            if (await _mediator.Send(new DoesMealExistByIdQuery(request.MealId)) == false)
                throw new EntityNotFoundException(nameof(request.MealId));

            if (await _mediator.Send(new IsIngredientChildOfMealQuery(request.IngredientId, request.MealId)) == false)
                throw new ArgumentException($"Ingredient with Id {request.IngredientId} is not a child of meal with Id {request.MealId}.");

            if (await _mediator.Send(new DoesProductExistByIdQuery(request.ProductId)) == false)
                throw new EntityNotFoundException(nameof(request.ProductId));

            if (await _mediator.Send(new DoesUnitExistByIdQuery(request.UnitId)) == false)
                throw new EntityNotFoundException(nameof(request.UnitId));
        }
    }
}