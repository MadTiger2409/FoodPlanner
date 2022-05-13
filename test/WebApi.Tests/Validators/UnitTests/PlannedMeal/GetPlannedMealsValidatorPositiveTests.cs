using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using FoodPlanner.WebApi.Validators.PlannedMeal;
using System;
using WebApi.Tests.Validators.TestData.PlannedMeal;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.PlannedMeal
{
    [Trait("Unit tests", "Validators")]
    public class GetPlannedMealsValidatorPositiveTests : ValidatorTestsBase<GetPlannedMealsValidator>
    {
        [Theory]
        [GetPlannedMealsValidatorCorrectDatesData]
        public void Should_Pass_Validation_For_StartDate(DateTime fromDate, DateTime toDate)
        {
            var model = new GetPlannedMeals { From = fromDate, To = toDate };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
