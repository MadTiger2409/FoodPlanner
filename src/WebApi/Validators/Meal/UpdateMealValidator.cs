using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Meal;

namespace FoodPlanner.WebApi.Validators.Meal
{
    public class UpdateMealValidator : AbstractValidator<UpdateMeal>
    {
        public UpdateMealValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(300);
        }
    }
}
