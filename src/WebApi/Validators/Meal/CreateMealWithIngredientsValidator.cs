using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Meal;
using FoodPlanner.WebApi.Validators.Ingredient;

namespace FoodPlanner.WebApi.Validators.Meal
{
    public class CreateMealWithIngredientsValidator : AbstractValidator<CreateMealWithIngredients>
    {
        public CreateMealWithIngredientsValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(300);

            RuleFor(x => x.Ingredients)
                .SetValidator(new CreateIngredientsValidator());
        }
    }
}