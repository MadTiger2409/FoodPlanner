using Domain.Common;
using System;

namespace Domain.Entities
{
    public class PlannedMeal : BaseEntity
    {
        public DateTime ScheduledFor { get; set; }
        public int MealId { get; set; }
        public int OrdinalNumber { get; set; }
        public Meal Meal { get; set; }
    }
}