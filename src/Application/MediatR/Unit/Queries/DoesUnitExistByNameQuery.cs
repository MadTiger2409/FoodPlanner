using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record DoesUnitExistByNameQuery(string Name) : IRequest<bool>;
}