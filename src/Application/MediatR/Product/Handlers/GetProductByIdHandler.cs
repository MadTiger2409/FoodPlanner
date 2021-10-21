using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<Domain.Entities.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (product == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return product;
        }
    }
}