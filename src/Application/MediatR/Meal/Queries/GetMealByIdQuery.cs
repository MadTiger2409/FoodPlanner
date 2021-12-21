using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Queries
{
    public record GetMealByIdQuery(int Id) : IRequest<Domain.Entities.Meal>;
}