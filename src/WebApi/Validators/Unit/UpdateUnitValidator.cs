using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Unit;

namespace FoodPlanner.WebApi.Validators.Unit
{
    public class UpdateUnitValidator : AbstractValidator<UpdateUnit>
    {
        public UpdateUnitValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}