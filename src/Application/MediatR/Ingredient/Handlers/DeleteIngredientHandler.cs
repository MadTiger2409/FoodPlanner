using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Ingredient.Commands;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
	public class DeleteIngredientHandler : IRequestHandler<DeleteIngredientCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly ISender _mediator;

		public DeleteIngredientHandler(IApplicationDbContext context, ISender mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<global::MediatR.Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
		{
			await _mediator.Send(new CanDeleteIngredientQuery(request.MealId, request.Id));

			var ingredient = await _context.Ingredients.FirstOrDefaultAsync(x => x.Id == request.Id);

			ingredient.Deleted = true;

			_context.Ingredients.Update(ingredient);
			await _context.SaveChangesAsync(cancellationToken);

			return global::MediatR.Unit.Value;
		}
	}
}
