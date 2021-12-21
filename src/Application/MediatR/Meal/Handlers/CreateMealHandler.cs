using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class CreateMealHandler : IRequestHandler<CreateMealCommand, Domain.Entities.Meal>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public CreateMealHandler(IApplicationDbContext dbContext, ISender mediator)
        {
            _context = dbContext;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Meal> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesMealExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var meal = new Domain.Entities.Meal { Name = request.Name };
            _context.Meals.Add(meal);

            await _context.SaveChangesAsync(cancellationToken);

            return meal;
        }
    }
}