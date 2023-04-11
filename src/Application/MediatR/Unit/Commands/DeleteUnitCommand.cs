using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Commands
{
	public record DeleteUnitCommand(int Id) : IRequest;
}
