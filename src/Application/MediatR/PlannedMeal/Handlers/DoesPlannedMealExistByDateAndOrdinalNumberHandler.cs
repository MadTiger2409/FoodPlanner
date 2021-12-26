using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class DoesPlannedMealExistByDateAndOrdinalNumberHandler : IRequestHandler<DoesPlannedMealExistByDateAndOrdinalNumberQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesPlannedMealExistByDateAndOrdinalNumberHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesPlannedMealExistByDateAndOrdinalNumberQuery request, CancellationToken cancellationToken)
            => await _context.PlannedMeals.AnyAsync(x => x.ScheduledFor.Date == request.ScheduledFor.Date && x.OrdinalNumber == request.OridinalNumber);
    }
}
