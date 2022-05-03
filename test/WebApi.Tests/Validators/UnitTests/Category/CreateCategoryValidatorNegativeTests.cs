using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Category;
using FoodPlanner.WebApi.Validators.Category;
using WebApi.Tests.Validators.TestData.Category;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Category
{
    [Trait("Unit tests", "Validators")]
    public class CreateCategoryValidatorNegativeTests : ValidatorTestsBase<CreateCategoryValidator>
    {
        [Theory]
        [CategoryValidatorIncorrectData]
        public void Should_Fail_Validation(string name)
        {
            var model = new CreateCategory { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.Name);
        }
    }
}
