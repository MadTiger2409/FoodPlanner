using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Category;
using FoodPlanner.Application.MediatR.Category.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            => _mapper.Map<List<CategoryDto>>(await _context.Categories.ToListAsync());
    }
}