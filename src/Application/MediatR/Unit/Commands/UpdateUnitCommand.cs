using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Commands
{
    public record UpdateUnitCommand(int Id, string Name) : IRequest<Domain.Entities.Unit>;
}