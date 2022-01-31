using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Product;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Product> query = _context.Products;

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            return _mapper.Map<List<ProductDto>>(await query.Include(x => x.Category).ToListAsync());
        }
    }
}