using FoodPlanner.Application.MediatR.Ingredient.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Ingredient
{
    public class UpdateIngredient
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }

        public static implicit operator UpdateIngredientCommand(UpdateIngredient ingredient)
        {
            return new UpdateIngredientCommand
            {
                ProductId = ingredient.ProductId,
                UnitId = ingredient.UnitId,
                Amount = ingredient.Amount
            };
        }
    }
}