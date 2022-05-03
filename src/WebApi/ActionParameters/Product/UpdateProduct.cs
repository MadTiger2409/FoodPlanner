using FoodPlanner.Application.MediatR.Product.Commands;

namespace FoodPlanner.WebApi.ActionParameters.Product
{
    public record UpdateProduct
    {
        private string name;

        public string Name
        {
            get => name;
            set => name = value?.Trim().ToLowerInvariant();
        }

        public int CategoryId { get; set; }

        public UpdateProductCommand GetUpdateProductCommand(int id) => new(id, CategoryId, Name);
    }
}