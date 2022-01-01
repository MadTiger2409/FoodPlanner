using FoodPlanner.Application.Mappings.Dtos.Meal;
using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Commands
{
    public record CreateMealCommand(string Name) : IRequest<MealDto>;
}