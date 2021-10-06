using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Unit.Queries
{
    public record DoesUnitExistsByNameQuery(string Name) : IRequest<bool>;
}