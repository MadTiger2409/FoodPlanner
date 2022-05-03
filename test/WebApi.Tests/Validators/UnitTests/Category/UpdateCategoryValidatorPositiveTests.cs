using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Category;
using FoodPlanner.WebApi.Validators.Category;
using System;
using WebApi.Tests.Validators.TestData.Category;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Category
{
    [Trait("Unit tests", "Validators")]
    public class UpdateCategoryValidatorPositiveTests : ValidatorTestsBase<UpdateCategoryValidator>
    {
        [Theory]
        [CategoryValidatorCorrectData]
        public void Should_Pass_Validation(string name)
        {
            var model = new UpdateCategory { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.Name);
        }
    }
}
