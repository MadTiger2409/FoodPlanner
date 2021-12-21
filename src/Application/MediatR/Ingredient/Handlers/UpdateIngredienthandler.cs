using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Ingredient.Commands;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredientCommand, Domain.Entities.Ingredient>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public UpdateIngredientHandler(IApplicationDbContext context, ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Ingredient> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CanUpdateIngredientQuery(request.UnitId, request.ProductId, request.MealId, request.IngredientId));

            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(x => x.Id == request.IngredientId);

            ingredient.ProductId = request.ProductId;
            ingredient.UnitId = request.UnitId;
            ingredient.Amount = request.Amount;

            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();

            return ingredient;
        }
    }
}