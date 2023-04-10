using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
	public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
	{
		private readonly IApplicationDbContext _context;

		public DeleteProductHandler(IApplicationDbContext context) => _context = context;

		public async Task<global::MediatR.Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _context.Products.Include(x => x.Ingredients).SingleOrDefaultAsync(x => x.Id == request.Id);

			if (product == null)
				throw new EntityNotFoundException(nameof(request.Id));

			if (product.Ingredients.Count > 0)
				throw new EntityNotRemovableException(product.Ingredients.Count);

			product.Deleted = true;

			_context.Products.Update(product);
			await _context.SaveChangesAsync(cancellationToken);

			return global::MediatR.Unit.Value;
		}
	}
}
