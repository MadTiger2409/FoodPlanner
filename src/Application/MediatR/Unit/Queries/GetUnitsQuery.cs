using FoodPlanner.Application.Mappings.Dtos.Unit;
using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record GetUnitsQuery : IRequest<List<UnitDto>>;
}