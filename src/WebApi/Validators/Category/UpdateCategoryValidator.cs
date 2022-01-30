using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Category;

namespace FoodPlanner.WebApi.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategory>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}