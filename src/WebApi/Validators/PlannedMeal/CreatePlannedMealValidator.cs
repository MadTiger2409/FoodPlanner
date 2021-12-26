using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Validators.PlannedMeal
{
    public class CreatePlannedMealValidator : AbstractValidator<CreatePlannedMeal>
    {
        public CreatePlannedMealValidator()
        {
            RuleFor(x => x.MealId)
                .GreaterThan(0);

            RuleFor(x => x.OrdinalNumber)
                .GreaterThan((uint)0);

            RuleFor(x => x.ScheduledFor.Date)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date);
        }
    }
}
