using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Commands
{
    public record CreateUnitCommand(string Name) : IRequest<Domain.Entities.Unit>;
}