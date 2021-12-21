using MediatR;

namespace FoodPlanner.Application.MediatR.Product.Queries
{
    public record DoesProductExistByIdQuery(int Id) : IRequest<bool>;
}