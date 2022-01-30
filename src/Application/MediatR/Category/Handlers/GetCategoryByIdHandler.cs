using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Category;
using FoodPlanner.Application.MediatR.Category.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Category.Handlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (category == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return _mapper.Map<CategoryDto>(category);
        }
    }
}