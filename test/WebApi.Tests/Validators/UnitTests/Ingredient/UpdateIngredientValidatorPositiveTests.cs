using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using FoodPlanner.WebApi.Validators.Ingredient;
using WebApi.Tests.Validators.TestData.Ingredient;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Ingredient
{
    [Trait("Unit tests", "Validators")]
    public class UpdateIngredientValidatorPositiveTests : ValidatorTestsBase<UpdateIngredientValidator>
    {
        [Theory]
        [IngredientValidatorCorrectProductIdData]
        public void Should_Pass_Validation_For_ProductId(int productId)
        {
            var model = new UpdateIngredient { ProductId = productId, UnitId = 1, Amount = 1f };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.ProductId);
        }

        [Theory]
        [IngredientValidatorCorrectUnitIdData]
        public void Should_Pass_Validation_For_UnitId(int unitId)
        {
            var model = new UpdateIngredient { ProductId = 1, UnitId = unitId, Amount = 1f };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.UnitId);
        }

        [Theory]
        [IngredientValidatorCorrectAmountData]
        public void Should_Pass_Validation_For_Amount(float amount)
        {
            var model = new UpdateIngredient { ProductId = 1, UnitId = 1, Amount = amount };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Amount);
        }
    }
}
