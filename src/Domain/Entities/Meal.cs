using FoodPlanner.Domain.Common;
using System.Collections.Generic;

namespace FoodPlanner.Domain.Entities
{
    public class Meal : NamedEntity
    {
        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public IList<PlannedMeal> PlannedMeals { get; set; } = new List<PlannedMeal>();
    }
}