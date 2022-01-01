using FoodPlanner.Application.Mappings.Dtos.Ingredient;
using MediatR;

namespace FoodPlanner.Application.MediatR.Ingredient.Commands
{
    public class UpdateIngredientCommand : IRequest<IngredientDto>
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }
    }
}