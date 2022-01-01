using FoodPlanner.Application.Mappings.Dtos.Meal;
using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Commands
{
    public record UpdateMealCommand(int Id, string Name) : IRequest<MealDto>;
}