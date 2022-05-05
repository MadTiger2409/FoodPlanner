using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using FoodPlanner.WebApi.Validators.Ingredient;
using System.Collections.Generic;
using WebApi.Tests.Validators.TestData.Ingredient;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Ingredient
{
    [Trait("Unit tests", "Validators")]
    public class CreateIngredientsValidatorNegativeTests : ValidatorTestsBase<CreateIngredientsValidator>
    {
        [Theory]
        [IngredientsValidatorIncorrectCountData]
        public void Should_Fail_Validation_For_Items_Count(List<CreateIngredient> ingredients)
        {
            var result = validator.TestValidate(ingredients);

            result.ShouldHaveValidationErrorFor(m => m.Count);
        }

        [Theory]
        [IngredientsValidatorIncorrectItemsData]
        public void Should_Fail_Validation_For_Items_Correctness(List<CreateIngredient> ingredients)
        {
            var result = validator.TestValidate(ingredients);

            result.ShouldHaveAnyValidationError();
        }
    }
}
