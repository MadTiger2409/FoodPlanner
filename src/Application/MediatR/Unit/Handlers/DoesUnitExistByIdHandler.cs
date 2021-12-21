using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class DoesUnitExistByIdHandler : IRequestHandler<DoesUnitExistByIdQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesUnitExistByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesUnitExistByIdQuery request, CancellationToken cancellationToken)
            => await _context.Units.AnyAsync(x => x.Id == request.Id);
    }
}