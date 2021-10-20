using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Queries
{
    public record DoesProductExistsByNameQuery(string Name) : IRequest<bool>;
}