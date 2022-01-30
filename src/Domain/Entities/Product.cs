using FoodPlanner.Domain.Common;
using System.Collections.Generic;

namespace FoodPlanner.Domain.Entities
{
    public class Product : NamedEntity
    {
        public int? CategoryId { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new();
        public Category Category { get; set; }
    }
}