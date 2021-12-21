using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class DoesProductExistByIdHandler : IRequestHandler<DoesProductExistByIdQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesProductExistByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesProductExistByIdQuery request, CancellationToken cancellationToken)
            => await _context.Products.AnyAsync(x => x.Id == request.Id);
    }
}