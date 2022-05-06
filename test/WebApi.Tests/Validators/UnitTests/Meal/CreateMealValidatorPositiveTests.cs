using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Meal;
using FoodPlanner.WebApi.Validators.Meal;
using WebApi.Tests.Validators.TestData.Meal;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Meal
{
    [Trait("Unit tests", "Validators")]
    public class CreateMealValidatorPositiveTests : ValidatorTestsBase<CreateMealValidator>
    {
        [Theory]
        [MealValidatorCorrectNameData]
        public void Should_Pass_Validation_For_Name(string name)
        {
            var model = new CreateMeal { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Name);
        }
    }
}
