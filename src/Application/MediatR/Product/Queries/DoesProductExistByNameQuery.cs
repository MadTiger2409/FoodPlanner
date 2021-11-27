using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Queries
{
    public record DoesProductExistByNameQuery(string Name) : IRequest<bool>;
}