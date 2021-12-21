using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IList<Domain.Entities.Product>>
    {
        private readonly IApplicationDbContext _context;

        public GetProductsHandler(IApplicationDbContext context) => _context = context;

        public async Task<IList<Domain.Entities.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            => await _context.Products.ToListAsync();
    }
}