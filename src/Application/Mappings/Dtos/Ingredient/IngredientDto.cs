using FoodPlanner.Application.Mappings.Dtos.Meal;

namespace FoodPlanner.Application.Mappings.Dtos.Ingredient
{
    public class IngredientDto
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public int UnitId { get; set; }
        public int ProductId { get; set; }
        public ShortMealDto Meal { get; set; }
    }
}
