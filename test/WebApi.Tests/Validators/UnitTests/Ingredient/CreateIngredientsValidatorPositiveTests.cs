using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using FoodPlanner.WebApi.Validators.Ingredient;
using System.Collections.Generic;
using WebApi.Tests.Validators.TestData.Ingredient;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Ingredient
{
    [Trait("Unit tests", "Validators")]
    public class CreateIngredientsValidatorPositiveTests : ValidatorTestsBase<CreateIngredientsValidator>
    {
        [Theory]
        [IngredientsValidatorCorrectCountData]
        public void Should_Pass_Validation_For_Items_Count(List<CreateIngredient> ingredients)
        {
            var result = validator.TestValidate(ingredients);

            result.ShouldNotHaveValidationErrorFor(m => m.Count);
        }

        [Theory]
        [IngredientsValidatorCorrectItemsData]
        public void Should_Pass_Validation_For_Items_Correctness(List<CreateIngredient> ingredients)
        {
            var result = validator.TestValidate(ingredients);

            result.ShouldNotHaveValidationErrorFor(m => m);
        }
    }
}
