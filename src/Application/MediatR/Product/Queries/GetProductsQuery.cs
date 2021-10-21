using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Product.Queries
{
    public record GetProductsQuery() : IRequest<IList<Domain.Entities.Product>>;
}