using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using System;

namespace FoodPlanner.WebApi.Validators.PlannedMeal
{
    public class CreatePlannedMealValidator : AbstractValidator<CreatePlannedMeal>
    {
        public CreatePlannedMealValidator()
        {
            RuleFor(x => x.MealId)
                .GreaterThan(0);

            RuleFor(x => x.OrdinalNumber)
                .GreaterThan((byte)0);

            RuleFor(x => x.OrdinalNumber)
                .LessThanOrEqualTo((byte)255);

            RuleFor(x => x.ScheduledFor.Date)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date);
        }
    }
}
