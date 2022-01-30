using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Category;
using FoodPlanner.Application.MediatR.Category.Commands;
using FoodPlanner.Application.MediatR.Category.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Category.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IApplicationDbContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesCategoryExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (category == null)
                throw new EntityNotFoundException(nameof(request.Id));

            category.Name = request.Name;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}