using FoodPlanner.Application.Mappings.Dtos.Product;
using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
}