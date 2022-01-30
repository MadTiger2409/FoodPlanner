using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Category;

namespace FoodPlanner.WebApi.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategory>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}