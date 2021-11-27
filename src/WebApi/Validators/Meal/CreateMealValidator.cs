using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Meal;

namespace FoodPlanner.WebApi.Validators.Meal
{
    public class CreateMealValidator : AbstractValidator<CreateMeal>
    {
        public CreateMealValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(300);
        }
    }
}