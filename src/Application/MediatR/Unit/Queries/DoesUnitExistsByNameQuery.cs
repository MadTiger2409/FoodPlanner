using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record DoesUnitExistsByNameQuery(string Name) : IRequest<bool>;
}