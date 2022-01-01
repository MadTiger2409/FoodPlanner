using FoodPlanner.Application.Mappings.Dtos.Meal;
using System;

namespace FoodPlanner.Application.Mappings.Dtos.PlannedMeal
{
    public class PlannedMealDto
    {
        public int Id { get; set; }
        public byte OrdinalNumber { get; set; }
        public DateTime ScheduledFor { get; set; }
        public MealDto Meal { get; set; }
    }
}
