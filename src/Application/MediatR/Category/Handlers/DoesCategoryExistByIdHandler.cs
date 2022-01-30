﻿using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Category.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Category.Handlers
{
    public class DoesCategoryExistByIdHandler : IRequestHandler<DoesCategoryExistByIdQuery, bool>
    {
        private readonly IApplicationDbContext _context;

        public DoesCategoryExistByIdHandler(IApplicationDbContext context) => _context = context;

        public async Task<bool> Handle(DoesCategoryExistByIdQuery request, CancellationToken cancellationToken)
            => await _context.Categories.AnyAsync(x => x.Id == request.Id);
    }
}