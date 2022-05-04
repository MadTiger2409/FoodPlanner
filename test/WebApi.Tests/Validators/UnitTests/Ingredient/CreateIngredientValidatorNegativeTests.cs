using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using FoodPlanner.WebApi.Validators.Ingredient;
using WebApi.Tests.Validators.TestData.Ingredient;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Ingredient
{
    [Trait("Unit tests", "Validators")]
    public class CreateIngredientValidatorNegativeTests : ValidatorTestsBase<CreateIngredientValidator>
    {
        [Theory]
        [IngredientValidatorIncorrectProductIdData]
        public void Should_Fail_Validation_For_ProductId(int productId)
        {
            var model = new CreateIngredient { ProductId = productId, UnitId = 1, Amount = 1f };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.ProductId);
        }

        [Theory]
        [IngredientValidatorIncorrectUnitIdData]
        public void Should_Fail_Validation_For_UnitId(int unitId)
        {
            var model = new CreateIngredient { ProductId = 1, UnitId = unitId, Amount = 1f };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.UnitId);
        }

        [Theory]
        [IngredientValidatorIncorrectAmountData]
        public void Should_Fail_Validation_For_Amount(float amount)
        {
            var model = new CreateIngredient { ProductId = 1, UnitId = 1, Amount = amount };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.Amount);
        }
    }
}
