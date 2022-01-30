using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Category.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Category.Handlers
{
    public class DoesCategoryExistByNameHandler : IRequestHandler<DoesCategoryExistByNameQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesCategoryExistByNameHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesCategoryExistByNameQuery request, CancellationToken cancellationToken)
            => await _context.Categories.AnyAsync(x => x.Name.ToLower().Equals(request.Name.ToLower()));
    }
}