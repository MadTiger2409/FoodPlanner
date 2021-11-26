using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class GetMealByIdHandler : IRequestHandler<GetMealByIdQuery, Domain.Entities.Meal>
    {
        private readonly IApplicationDbContext _context;

        public GetMealByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<Domain.Entities.Meal> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await _context.Meals
                                .Include(x => x.Ingredients).ThenInclude(y => y.Product)
                                .Include(x => x.Ingredients).ThenInclude(y => y.Unit)
                                .SingleOrDefaultAsync(z => z.Id == request.Id);

            if (meal == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return meal;
        }
    }
}