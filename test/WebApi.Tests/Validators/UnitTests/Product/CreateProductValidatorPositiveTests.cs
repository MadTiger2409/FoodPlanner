using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Product;
using FoodPlanner.WebApi.Validators.Product;
using WebApi.Tests.Validators.TestData.Product;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Product
{
    [Trait("Unit tests", "Validators")]
    public class CreateProductValidatorPositiveTests : ValidatorTestsBase<CreateProductValidator>
    {
        [Theory]
        [ProductValidatorCorrectNameData]
        public void Should_Pass_Validation_For_Name(string name)
        {
            var model = new CreateProduct { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Name);
        }
    }
}
