﻿using FluentValidation.TestHelper;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using FoodPlanner.WebApi.Validators.PlannedMeal;
using System;
using WebApi.Tests.Validators.TestData.PlannedMeal;
using Xunit;

namespace WebApi.Tests.Validators.UnitTests.PlannedMeal
{
    [Trait("Unit tests", "Validators")]
    public class CreatePlannedMealValidatorPositiveTests : ValidatorTestsBase<CreatePlannedMealValidator>
    {
        [Theory]
        [PlannedMealValidatorCorrectMealIdData]
        public void Should_Pass_Validation_For_MealId(int mealId)
        {
            var model = new CreatePlannedMeal
            {
                MealId = mealId,
                OrdinalNumber = 1,
                ScheduledFor = DateTime.UtcNow.Date
            };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.MealId);
        }

        [Theory]
        [PlannedMealValidatorCorrectOrdinalNumberData]
        public void Should_Pass_Validation_For_OrdinalNumber(byte ordinalNumber)
        {
            var model = new CreatePlannedMeal
            {
                MealId = 1,
                OrdinalNumber = ordinalNumber,
                ScheduledFor = DateTime.UtcNow.Date
            };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.OrdinalNumber);
        }

        [Theory]
        [PlannedMealValidatorCorrectScheduledForData]
        public void Should_Pass_Validation_For_ScheduledFor(DateTime scheduledFor)
        {
            var model = new CreatePlannedMeal
            {
                MealId = 1,
                OrdinalNumber = 1,
                ScheduledFor = scheduledFor
            };

            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(m => m.ScheduledFor.Date);
        }
    }
}
