using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Ingredient;

namespace FoodPlanner.WebApi.Validators.Ingredient
{
    public class CreateIngredientValidator : AbstractValidator<CreateIngredient>
    {
        public CreateIngredientValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0);

            RuleFor(x => x.UnitId)
                .GreaterThan(0);

            RuleFor(x => x.Amount)
                .GreaterThan(0.0f);
        }
    }
}