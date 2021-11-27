using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class DoesProductExistByNameHandler : IRequestHandler<DoesProductExistByNameQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesProductExistByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesProductExistByNameQuery request, CancellationToken cancellationToken)
            => await _context.Products.AnyAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));
    }
}