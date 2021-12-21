using MediatR;

namespace FoodPlanner.Application.MediatR.Ingredient.Queries
{
    public record IsIngredientChildOfMealQuery(int IngredientId, int MealId) : IRequest<bool>;
}