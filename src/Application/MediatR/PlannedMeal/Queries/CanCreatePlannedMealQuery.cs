using MediatR;
using System;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record CanCreatePlannedMealQuery(int MealId, uint OrdinalNumber, DateTime ScheduledFor) : IRequest;
}
