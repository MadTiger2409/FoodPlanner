using FoodPlanner.Application.Mappings.Dtos.Meal;

namespace FoodPlanner.Application.Mappings.Dtos.PlannedMeal
{
    public class PlannedMealForGroupingDto
    {
        public int Id { get; set; }
        public byte OrdinalNumber { get; set; }
        public MealDto Meal { get; set; }
    }
}