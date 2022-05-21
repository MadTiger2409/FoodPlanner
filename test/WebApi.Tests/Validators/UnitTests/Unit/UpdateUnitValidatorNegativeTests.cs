using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Unit;
using FoodPlanner.WebApi.Validators.Unit;
using WebApi.Tests.Validators.TestData.Unit;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Unit
{
    [Trait("Unit tests", "Validators")]
    public class UpdateUnitValidatorNegativeTests : ValidatorTestsBase<UpdateUnitValidator>
    {
        [Theory]
        [UnitValidatorIncorrectNameData]
        public void Should_Fail_Validation_For_Name(string name)
        {
            var model = new UpdateUnit { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.Name);
        }
    }
}
