﻿using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.Product;
using FoodPlanner.WebApi.Validators.Product;
using WebApi.Tests.Validators.TestData.Product;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.Product
{
    [Trait("Unit tests", "Validators")]
    public class UpdateProductValidatorNegativeTests : ValidatorTestsBase<UpdateProductValidator>
    {
        [Theory]
        [ProductValidatorIncorrectNameData]
        public void Should_Fail_Validation_For_Name(string name)
        {
            var model = new UpdateProduct { Name = name };
            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.Name);
        }
    }
}
