using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Category;
using FoodPlanner.Application.MediatR.Category.Commands;
using FoodPlanner.Application.MediatR.Category.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Category.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IApplicationDbContext dbContext, ISender mediator, IMapper mapper)
        {
            _context = dbContext;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesCategoryExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var category = new Domain.Entities.Category { Name = request.Name };
            _context.Categories.Add(category);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}