using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record GetUnitsQuery : IRequest<IList<Domain.Entities.Unit>>;
}