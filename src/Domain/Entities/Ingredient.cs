using FoodPlanner.Domain.Common;
using System;

namespace FoodPlanner.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        private float amount;
        private int productId;
        private int unitId;

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

        public int ProductId
        {
            get => productId;

            set
            {
                if (value < 1)
                    throw new ArgumentException("'ProductId' must be positive.");

                productId = value;
            }
        }

        public int UnitId
        {
            get => unitId;

            set
            {
                if (value < 1)
                    throw new ArgumentException("'UnitId' must be positive.");

                unitId = value;
            }
        }

        public int MealId { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }
        public Meal Meal { get; set; }
    }
}