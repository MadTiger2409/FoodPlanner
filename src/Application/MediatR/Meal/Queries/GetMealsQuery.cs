using FoodPlanner.Application.Mappings.Dtos.Meal;
using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Meal.Queries
{
    public record GetMealsQuery(string Name = default) : IRequest<List<MealDto>>;
}