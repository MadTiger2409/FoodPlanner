using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class UpdateMealHandler : IRequestHandler<UpdateMealCommand, Domain.Entities.Meal>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public UpdateMealHandler(IApplicationDbContext context, ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Meal> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesMealExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var meal = await _mediator.Send(new GetMealByIdQuery(request.Id));
            meal.Name = request.Name;

            _context.Meals.Update(meal);
            await _context.SaveChangesAsync(cancellationToken);

            return meal;
        }
    }
}