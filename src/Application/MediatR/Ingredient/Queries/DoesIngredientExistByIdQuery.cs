using MediatR;

namespace FoodPlanner.Application.MediatR.Ingredient.Queries
{
    public record DoesIngredientExistByIdQuery(int Id) : IRequest<bool>;
}