using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Meal;
using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class CreateMealHandler : IRequestHandler<CreateMealCommand, MealDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreateMealHandler(IApplicationDbContext dbContext, ISender mediator, IMapper mapper)
        {
            _context = dbContext;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<MealDto> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesMealExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var meal = new Domain.Entities.Meal { Name = request.Name };
            _context.Meals.Add(meal);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<MealDto>(meal);
        }
    }
}