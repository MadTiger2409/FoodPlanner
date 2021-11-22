using FoodPlanner.Domain.Common;
using System;

namespace FoodPlanner.Domain.Entities
{
    public class PlannedMeal : BaseEntity
    {
        private int mealId;
        private int ordinalNumber;

        public DateTime ScheduledFor { get; set; }

        public int MealId
        {
            get => mealId;
            set
            {
                if (value < 1)
                    throw new ArgumentException("'MealId' must be positive.");

                mealId = value;
            }
        }

        public int OrdinalNumber
        {
            get => ordinalNumber;
            set
            {
                if (value < 1)
                    throw new ArgumentException("'OrdinalNumber' must be positive.");

                ordinalNumber = value;
            }
        }

        public Meal Meal { get; set; }
    }
}