using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Commands
{
    public record CreateMealCommand(string Name) : IRequest<Domain.Entities.Meal>;
}