using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Unit;
using FoodPlanner.WebApi.Validators.Unit;
using WebApi.Tests.Validators.TestData.Unit;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Unit
{
    [Trait("Unit tests", "Validators")]
    public class UpdateUnitValidatorPositiveTests : ValidatorTestsBase<UpdateUnitValidator>
    {
        [Theory]
        [UnitValidatorCorrectNameData]
        public void Should_Pass_Validation_For_Name(string name)
        {
            var model = new UpdateUnit { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Name);
        }
    }
}
