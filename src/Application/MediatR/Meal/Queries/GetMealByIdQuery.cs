using FoodPlanner.Application.Mappings.Dtos.Meal;
using MediatR;

namespace FoodPlanner.Application.MediatR.Meal.Queries
{
    public record GetMealByIdQuery(int Id) : IRequest<MealDto>;
}