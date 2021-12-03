using FoodPlanner.Domain.Common;
using System;

namespace FoodPlanner.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        private float amount;

        public float Amount
        {
            get => amount;

            set
            {
                if (value <= 0)
                    throw new ArgumentException("'Amount' must be positive.");

                amount = value;
            }
        }

        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public int MealId { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }
        public Meal Meal { get; set; }
    }
}