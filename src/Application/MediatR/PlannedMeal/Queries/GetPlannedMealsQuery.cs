using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using MediatR;
using System;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record GetPlannedMealsQuery(DateTime From, DateTime To) : IRequest<List<PlannedMealDto>>;
}