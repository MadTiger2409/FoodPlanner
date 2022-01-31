using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Category;
using FoodPlanner.Application.MediatR.Category.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Category.Handlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Domain.Entities.Category> query = _context.Categories;

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            return _mapper.Map<List<CategoryDto>>(await query.ToListAsync());
        }
    }
}