using FoodPlanner.Domain.Common;
using System;

namespace FoodPlanner.Domain.Entities
{
    public class PlannedMeal : BaseEntity
    {
        private byte ordinalNumber;

        public DateTime ScheduledFor { get; set; }

        public int MealId { get; set; }
        
        public Meal Meal { get; set; }

        public byte OrdinalNumber
        {
            get => ordinalNumber;
            set
            {
                if (value < 1)
                    throw new ArgumentException($"'{nameof(OrdinalNumber)}' must be positive.");

                ordinalNumber = value;
            }
        }
    }
}