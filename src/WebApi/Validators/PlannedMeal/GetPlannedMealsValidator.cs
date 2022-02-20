using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;

namespace FoodPlanner.WebApi.Validators.PlannedMeal
{
    public class GetPlannedMealsValidator : AbstractValidator<GetPlannedMeals>
    {
        public GetPlannedMealsValidator()
        {
            RuleFor(x => x)
                .Must(x => (x.To.Date - x.From.Date).TotalDays >= 0)
                .WithMessage("End date can't be lower than start date");

            RuleFor(x => x)
                .Must(x => (x.To.Date - x.From.Date).TotalDays <= 31)
                .WithMessage("Date range can't be bigger than 31 days");
        }
    }
}