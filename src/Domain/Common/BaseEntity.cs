using System;

namespace FoodPlanner.Domain.Common
{
    public abstract class BaseEntity
    {
        private int id;

        public int Id
        {
            get => id;

            set
            {
                if (value < 1)
                    throw new ArgumentException("'Id' must be positive.");

                id = value;
            }
        }
    }
}