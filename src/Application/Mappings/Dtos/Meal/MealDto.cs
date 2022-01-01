using FoodPlanner.Application.Mappings.Dtos.Ingredient;
using System.Collections.Generic;

namespace FoodPlanner.Application.Mappings.Dtos.Meal
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientForMealDto> Ingredients { get; set; }
    }
}
