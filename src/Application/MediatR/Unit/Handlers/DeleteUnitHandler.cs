using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
	public class DeleteUnitHandler : IRequestHandler<DeleteUnitCommand>
	{
		private readonly IApplicationDbContext _context;

		public DeleteUnitHandler(IApplicationDbContext context) => _context = context;

		public async Task<global::MediatR.Unit> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
		{
			var unit = await _context.Units.Include(x => x.Ingredients).SingleOrDefaultAsync(x => x.Id == request.Id);

			if (unit == null)
				throw new EntityNotFoundException(nameof(request.Id));

			if (unit.Ingredients.Count > 0)
				throw new EntityNotRemovableException(unit.Ingredients.Count);

			unit.Deleted = true;

			_context.Units.Update(unit);
			await _context.SaveChangesAsync(cancellationToken);

			return global::MediatR.Unit.Value;
		}
	}
}
