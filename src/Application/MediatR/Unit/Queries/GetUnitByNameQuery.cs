using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record GetUnitByNameQuery(string Name) : IRequest<Domain.Entities.Unit>;
}