using FoodPlanner.Application.MediatR.Product.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Product
{
    public record CreateProduct
    {
        public string Name { get; set; }

        public CreateProductCommand GetCreateProductCommand() => new(Name);
    }
}