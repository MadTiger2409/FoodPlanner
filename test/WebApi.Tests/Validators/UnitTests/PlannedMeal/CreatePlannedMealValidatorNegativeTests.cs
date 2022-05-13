using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using FoodPlanner.WebApi.Validators.PlannedMeal;
using System;
using WebApi.Tests.Validators.TestData.PlannedMeal;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.PlannedMeal
{
    [Trait("Unit tests", "Validators")]
    public class CreatePlannedMealValidatorNegativeTests : ValidatorTestsBase<CreatePlannedMealValidator>
    {
        [Theory]
        [PlannedMealValidatorIncorrectMealIdData]
        public void Should_Fail_Validation_For_MealId(int mealId)
        {
            var model = new CreatePlannedMeal
            {
                MealId = mealId,
                OrdinalNumber = 1,
                ScheduledFor = DateTime.UtcNow.Date
            };

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.MealId);
        }

        [Theory]
        [PlannedMealValidatorIncorrectOrdinalNumberData]
        public void Should_Fail_Validation_For_OrdinalNumber(byte ordinalNumber)
        {
            var model = new CreatePlannedMeal
            {
                MealId = 1,
                OrdinalNumber = ordinalNumber,
                ScheduledFor = DateTime.UtcNow.Date
            };

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.OrdinalNumber);
        }

        [Theory]
        [PlannedMealValidatorIncorrectScheduledForData]
        public void Should_Fail_Validation_For_ScheduledFor(DateTime scheduledFor)
        {
            var model = new CreatePlannedMeal
            {
                MealId = 1,
                OrdinalNumber = 1,
                ScheduledFor = scheduledFor
            };

            var result = validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(m => m.ScheduledFor.Date);
        }
    }
}
