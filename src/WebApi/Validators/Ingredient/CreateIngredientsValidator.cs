using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using System.Collections.Generic;

namespace FoodPlanner.WebApi.Validators.Ingredient
{
    public class CreateIngredientsValidator : AbstractValidator<List<CreateIngredient>>
    {
        public CreateIngredientsValidator()
        {
            RuleFor(x => x.Count).InclusiveBetween(1, 50).WithMessage("The list of ingredients should contain from one to fifty items.");
            RuleForEach(x => x).SetValidator(new CreateIngredientValidator());
        }
    }
}