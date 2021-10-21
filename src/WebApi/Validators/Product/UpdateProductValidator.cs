using FluentValidation;
using FoodPlanner.WebApi.ActionParameters.Product;

namespace FoodPlanner.WebApi.Validators.Product
{
    public class UpdateProductValidator : AbstractValidator<UpdateProduct>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);
        }
    }
}