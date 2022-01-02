using FoodPlanner.Application.MediatR.PlannedMeal.Commands;
using System;

namespace FoodPlanner.WebApi.ActionParameters.PlannedMeal
{
    public record CreatePlannedMeal
    {
        public byte OrdinalNumber { get; set; }
        public DateTime ScheduledFor { get; set; }
        public int MealId { get; set; }

        public CreatePlannedMealCommand GetCreatePlannedMealCommand()
            => new(OrdinalNumber, ScheduledFor, MealId);
    }
}