using MediatR;

namespace FoodPlanner.Application.MediatR.Ingredient.Commands
{
	public record DeleteIngredientCommand(int MealId, int Id) : IRequest;
}
