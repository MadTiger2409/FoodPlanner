using System;

namespace FoodPlanner.Domain.Common
{
    public abstract class NamedEntity : BaseEntity
    {
        private string name;

        public string Name
        {
            get => name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("'Name' can't be empty or consists of whitespaces only.");

                name = value;
            }
        }
    }
}