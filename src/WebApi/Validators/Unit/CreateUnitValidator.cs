using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Unit;

namespace FoodPlanner.WebApi.Validators.Unit
{
    public class CreateUnitValidator : AbstractValidator<CreateUnit>
    {
        public CreateUnitValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}