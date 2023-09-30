using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Meal.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class DeleteMealHandler : IRequestHandler<DeleteMealCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMealHandler(IApplicationDbContext context) => _context = context;

        public async Task Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _context.Meals.Include(x => x.Ingredients).FirstOrDefaultAsync(x => x.Id == request.Id);

            if (meal == null)
                throw new EntityNotFoundException(nameof(request.Id));

            if (meal.Ingredients.Count > 0)
            {
                foreach (var ingredient in meal.Ingredients)
                {
                    ingredient.Deleted = true;
                }
            }

            meal.Deleted = true;

            _context.Meals.Update(meal);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
