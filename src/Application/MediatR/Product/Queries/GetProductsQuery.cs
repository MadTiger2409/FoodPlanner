using FoodPlanner.Application.Mappings.Dtos.Product;
using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Product.Queries
{
    public record GetProductsQuery(string Name = default) : IRequest<List<ProductDto>>;
}