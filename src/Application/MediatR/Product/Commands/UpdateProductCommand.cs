using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Commands
{
    public record UpdateProductCommand(int Id, string Name) : IRequest<Domain.Entities.Product>;
}