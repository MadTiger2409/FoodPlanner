using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class DoesIngredientExistByIdHandler : IRequestHandler<DoesIngredientExistByIdQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesIngredientExistByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesIngredientExistByIdQuery request, CancellationToken cancellationToken)
            => await _context.Ingredients.AnyAsync(x => x.Id == request.Id);
    }
}