using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
	public class CanDeleteIngredientHandler : IRequestHandler<CanDeleteIngredientQuery>
	{
		private readonly ISender _mediator;

		public CanDeleteIngredientHandler(ISender mediator) => _mediator = mediator;

		public async Task<global::MediatR.Unit> Handle(CanDeleteIngredientQuery request, CancellationToken cancellationToken)
		{
			if (await _mediator.Send(new DoesIngredientExistByIdQuery(request.IngredientId)) == false)
				throw new EntityNotFoundException(nameof(request.IngredientId));

			if (await _mediator.Send(new DoesMealExistByIdQuery(request.MealId)) == false)
				throw new EntityNotFoundException(nameof(request.MealId));

			if (await _mediator.Send(new IsIngredientChildOfMealQuery(request.IngredientId, request.MealId)) == false)
				throw new ArgumentException($"Ingredient with Id {request.IngredientId} is not a child of meal with Id {request.MealId}.");

			return global::MediatR.Unit.Value;
		}
	}
}
