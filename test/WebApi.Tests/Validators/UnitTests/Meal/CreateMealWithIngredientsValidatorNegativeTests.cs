using FluentAssertions;
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
    public class CreateMealWithIngredientsValidatorNegativeTests : ValidatorTestsBase<CreateMealWithIngredientsValidator>
    {
        [Theory]
        [MealValidatorIncorrectNameData]
        public void Should_Fail_Validation_For_Name(string name)
        {
            var model = new CreateMealWithIngredients
            {
                Name = name,
                Ingredients = new()
                {
                    new() { Amount = 1f, ProductId = 1, UnitId = 2 }
                }

            };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.Name);
        }

        [Theory]
        [IngredientsValidatorIncorrectCountData]
        public void Should_Fail_Validation_For_Items_Count(List<CreateIngredient> ingredients)
        {
            var model = new CreateMealWithIngredients
            {
                Name = "Test meal",
                Ingredients = ingredients
            };

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.Ingredients.Count);
        }

        [Theory]
        [IngredientsValidatorIncorrectItemsData]
        public void Should_Fail_Validation_For_Items_Correctness(List<CreateIngredient> ingredients)
        {
            var model = new CreateMealWithIngredients
            {
                Name = "Test meal",
                Ingredients = ingredients
            };

            var result = validator.TestValidate(model);

            result.Errors.Should().NotBeEmpty().And.HaveCountGreaterThanOrEqualTo(1);
        }
    }
}
