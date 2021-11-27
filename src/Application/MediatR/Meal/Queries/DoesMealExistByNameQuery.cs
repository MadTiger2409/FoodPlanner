using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Queries
{
    public record DoesMealExistByNameQuery(string Name) : IRequest<bool>;
}