using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record GetPlannedMealsQuery() : IRequest<List<PlannedMealDto>>;
}
