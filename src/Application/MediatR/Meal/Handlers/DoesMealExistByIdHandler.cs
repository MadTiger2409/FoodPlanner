using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class DoesMealExistByIdHandler : IRequestHandler<DoesMealExistByIdQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesMealExistByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesMealExistByIdQuery request, CancellationToken cancellationToken)
            => await _context.Meals.AnyAsync(x => x.Id == request.id);
    }
}