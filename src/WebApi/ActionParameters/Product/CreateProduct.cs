using FoodPlanner.Application.MediatR.Product.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Product
{
    public record CreateProduct
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value.Trim().ToLowerInvariant();
        }

        public CreateProductCommand GetCreateProductCommand() => new(Name);
    }
}