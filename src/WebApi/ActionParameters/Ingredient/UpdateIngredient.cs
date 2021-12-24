using FoodPlanner.Application.MediatR.Ingredient.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Ingredient
{
    public class UpdateIngredient
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }

        public UpdateIngredientCommand GetUpdateIngredientCommand(int mealId, int ingredientId)
        {
            return new UpdateIngredientCommand
            {
                ProductId = ProductId,
                UnitId = UnitId,
                Amount = Amount,
                MealId = mealId,
                IngredientId = ingredientId
            };
        }
    }
}