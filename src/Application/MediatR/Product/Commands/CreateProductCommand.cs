using FoodPlanner.Application.Mappings.Dtos.Product;
using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Commands
{
    public record CreateProductCommand(string Name) : IRequest<ProductDto>;
}