using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Category.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Category.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryHandler(IApplicationDbContext context) => _context = context;

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == request.Id);

            if (category == null)
                throw new EntityNotFoundException(nameof(request.Id));

            if (category.Products.Count > 0)
                throw new EntityNotRemovableException(category.Products.Count);

            category.Deleted = true;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
