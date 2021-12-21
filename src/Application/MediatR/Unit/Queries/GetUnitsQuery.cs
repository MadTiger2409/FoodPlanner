using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record GetUnitsQuery : IRequest<IList<Domain.Entities.Unit>>;
}