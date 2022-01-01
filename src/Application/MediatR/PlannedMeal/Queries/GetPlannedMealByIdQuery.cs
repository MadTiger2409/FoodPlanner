using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using MediatR;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record GetPlannedMealByIdQuery(int Id) : IRequest<PlannedMealDto>;
}
