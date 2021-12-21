using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Queries
{
    public record DoesMealExistByIdQuery(int Id) : IRequest<bool>;
}