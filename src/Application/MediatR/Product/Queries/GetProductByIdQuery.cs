using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Domain.Entities.Product>;
}