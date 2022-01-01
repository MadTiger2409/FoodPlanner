using FoodPlanner.Application.Mappings.Dtos.Unit;
using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Commands
{
    public record UpdateUnitCommand(int Id, string Name) : IRequest<UnitDto>;
}