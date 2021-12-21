using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Queries
{
    public record DoesUnitExistByIdQuery(int Id) : IRequest<bool>;
}