using FoodPlanner.Domain.Common;
using System;

namespace FoodPlanner.Domain.Entities
{
    public class PlannedMeal : BaseEntity
    {
        public DateTime ScheduledFor { get; set; }
        public int MealId { get; set; }
        public int OrdinalNumber { get; set; }
        public Meal Meal { get; set; }
    }
}