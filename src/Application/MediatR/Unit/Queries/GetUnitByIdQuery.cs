using FoodPlanner.Application.Mappings.Dtos.Unit;
using MediatR;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record GetUnitByIdQuery(int Id) : IRequest<UnitDto>;
}