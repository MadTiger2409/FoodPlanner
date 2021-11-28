using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Validators.Ingredient
{
    public class CreateIngredientsValidator : AbstractValidator<List<CreateIngredient>>
    {
        public CreateIngredientsValidator()
        {
            RuleForEach(x => x).SetValidator(new CreateIngredientValidator());
        }
    }
}