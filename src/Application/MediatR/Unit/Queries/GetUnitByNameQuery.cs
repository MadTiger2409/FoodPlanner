using FoodPlanner.Application.Mappings.Dtos.Unit;
using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record GetUnitByNameQuery(string Name) : IRequest<UnitDto>;
}