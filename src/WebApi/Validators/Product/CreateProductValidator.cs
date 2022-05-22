using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Product;

namespace FoodPlanner.WebApi.Validators.Product
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.CategoryId)
                .GreaterThanOrEqualTo(1);
        }
    }
}