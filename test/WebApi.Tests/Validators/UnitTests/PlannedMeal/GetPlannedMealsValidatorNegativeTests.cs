using FluentAssertions;
using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using FoodPlanner.WebApi.Validators.PlannedMeal;
using System;
using WebApi.Tests.Validators.TestData.PlannedMeal;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.PlannedMeal
{
    [Trait("Unit tests", "Validators")]
    public class GetPlannedMealsValidatorNegativeTests : ValidatorTestsBase<GetPlannedMealsValidator>
    {
        [Theory]
        [GetPlannedMealsValidatorIncorrectDatesData]
        public void Should_Fail_Validation_For_Dates(DateTime fromDate, DateTime toDate)
        {
            var model = new GetPlannedMeals { From = fromDate, To = toDate };

            var result = validator.TestValidate(model);

            result.Errors.Should().NotBeNull().And.HaveCount(1);
        }
    }
}
