using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Unit.Commands
{
    public record CreateUnitCommand(string Name) : IRequest<Domain.Entities.Unit>;
}