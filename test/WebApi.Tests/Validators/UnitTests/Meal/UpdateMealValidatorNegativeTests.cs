using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Meal;
using FoodPlanner.WebApi.Validators.Meal;
using WebApi.Tests.Validators.TestData.Meal;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Meal
{
    [Trait("Unit tests", "Validators")]
    public class UpdateMealValidatorNegativeTests : ValidatorTestsBase<UpdateMealValidator>
    {
        [Theory]
        [MealValidatorIncorrectNameData]
        public void Should_Fail_Validation_For_Name(string name)
        {
            var model = new UpdateMeal { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.Name);
        }
    }
}
