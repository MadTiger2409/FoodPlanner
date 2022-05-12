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
                .InclusiveBetween((byte)1, (byte)255);

            RuleFor(x => x.ScheduledFor.Date)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date);
        }
    }
}
