using MediatR;

namespace FoodPlanner.Application.MediatR.Ingredient.Queries
{
	public record CanDeleteIngredientQuery(int MealId, int IngredientId) : IRequest;
}
