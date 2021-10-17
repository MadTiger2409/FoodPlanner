using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record GetUnitByIdQuery(int Id) : IRequest<Domain.Entities.Unit>;
}