using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using FoodPlanner.WebApi.ActionParameters.Meal;
using FoodPlanner.WebApi.Validators.Meal;
using System.Collections.Generic;
using WebApi.Tests.Validators.TestData.Ingredient;
using WebApi.Tests.Validators.TestData.Meal;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Meal
{
    [Trait("Unit tests", "Validators")]
    public class CreateMealWithIngredientsValidatorPositiveTests : ValidatorTestsBase<CreateMealWithIngredientsValidator>
    {
        [Theory]
        [MealValidatorCorrectNameData]
        public void Should_Pass_Validation_For_Name(string name)
        {
            var model = new CreateMealWithIngredients
            {
                Name = name,
                Ingredients = new()
                {
                    new() { Amount = 1, ProductId = 1, UnitId = 2 }
                }
            };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Name);
        }

        [Theory]
        [IngredientsValidatorCorrectCountData]
        public void Should_Pass_Validation_For_Items_Count(List<CreateIngredient> ingredients)
        {
            var model = new CreateMealWithIngredients
            {
                Name = "Test meal",
                Ingredients = ingredients
            };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Ingredients.Count);
        }

        [Theory]
        [IngredientsValidatorCorrectItemsData]
        public void Should_Pass_Validation_For_Items_Correctness(List<CreateIngredient> ingredients)
        {
            var model = new CreateMealWithIngredients
            {
                Name = "Test meal",
                Ingredients = ingredients
            };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Ingredients);
        }
    }
}
