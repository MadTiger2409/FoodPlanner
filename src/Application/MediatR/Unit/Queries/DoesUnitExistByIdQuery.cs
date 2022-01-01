using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record DoesUnitExistByIdQuery(int Id) : IRequest<bool>;
}