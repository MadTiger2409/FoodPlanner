using FoodPlanner.Domain.Common;
using System.Collections.Generic;

namespace FoodPlanner.Domain.Entities
{
    public class Meal : NamedEntity
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<PlannedMeal> PlannedMeals { get; set; } = new List<PlannedMeal>();
    }
}