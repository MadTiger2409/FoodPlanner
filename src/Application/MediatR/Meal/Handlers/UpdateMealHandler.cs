using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Meal;
using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class UpdateMealHandler : IRequestHandler<UpdateMealCommand, MealDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UpdateMealHandler(IApplicationDbContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<MealDto> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesMealExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var meal = await _context.Meals
                .Include(x => x.Ingredients).ThenInclude(y => y.Product)
                .Include(x => x.Ingredients).ThenInclude(y => y.Unit)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (meal == null)
                throw new EntityNotFoundException(nameof(request.Id));

            meal.Name = request.Name;

            _context.Meals.Update(meal);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<MealDto>(meal);
        }
    }
}