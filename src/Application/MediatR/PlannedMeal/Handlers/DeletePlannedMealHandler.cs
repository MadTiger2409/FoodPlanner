using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.PlannedMeal.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class DeletePlannedMealHandler : IRequestHandler<DeletePlannedMealCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePlannedMealHandler(IApplicationDbContext context) => _context = context;

        public async Task Handle(DeletePlannedMealCommand request, CancellationToken cancellationToken)
        {
            var plannedMeal = await _context.PlannedMeals.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (plannedMeal == null)
                throw new EntityNotFoundException(nameof(request.Id));

            plannedMeal.Deleted = true;

            _context.PlannedMeals.Update(plannedMeal);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
