using FoodPlanner.Application.MediatR.Product.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Product
{
    public record UpdateProduct
    {
        public string Name { get; set; }

        public UpdateProductCommand GetUpdateProductCommand(int id) => new(id, Name);
    }
}