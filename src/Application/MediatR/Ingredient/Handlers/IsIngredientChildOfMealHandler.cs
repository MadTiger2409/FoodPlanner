using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class IsIngredientChildOfMealHandler : IRequestHandler<IsIngredientChildOfMealQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public IsIngredientChildOfMealHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(IsIngredientChildOfMealQuery request, CancellationToken cancellationToken)
            => await _context.Ingredients.AnyAsync(x => x.Id == request.IngredientId && x.MealId == request.MealId);
    }
}