using FoodPlanner.Application.Mappings.Dtos.Product;
using FoodPlanner.Application.Mappings.Dtos.Unit;

namespace FoodPlanner.Application.Mappings.Dtos.Ingredient
{
    public class IngredientForMealDto
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public ProductDto Product { get; set; }
        public UnitDto Unit { get; set; }
    }
}
