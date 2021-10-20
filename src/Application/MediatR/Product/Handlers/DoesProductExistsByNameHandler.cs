using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class DoesProductExistsByNameHandler : IRequestHandler<DoesProductExistsByNameQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesProductExistsByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesProductExistsByNameQuery request, CancellationToken cancellationToken) =>
            await _context.Products.AnyAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));
    }
}