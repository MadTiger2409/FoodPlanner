using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using MediatR;
using System;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Commands
{
    public record CreatePlannedMealCommand(byte OrdinalNumber, DateTime ScheduledFor, int MealId) : IRequest<PlannedMealDto>;
}
