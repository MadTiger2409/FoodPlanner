using MediatR;

namespace FoodPlanner.Application.MediatR.Ingredient.Queries
{
    public record CanUpdateIngredientQuery(int UnitId, int ProductId, int MealId, int IngredientId) : IRequest;
}