using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Category;
using FoodPlanner.WebApi.Validators.Category;
using System;
using WebApi.Tests.Validators.TestData.Category;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Category
{
    [Trait("Unit tests", "Validators")]
    public class CreateCategoryValidatorPositiveTests : ValidatorTestsBase<CreateCategoryValidator>
    {
        [Theory]
        [CategoryValidatorCorrectData]
        public void Should_Pass_Validation(string name)
        {
            var model = new CreateCategory { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Name);
        }
    }
}
