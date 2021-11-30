using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Ingredient.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class CreateIngredientsHandler : IRequestHandler<CreateIngredientsCommand, List<Domain.Entities.Ingredient>>
    {
        private readonly IApplicationDbContext _context;

        public CreateIngredientsHandler(IApplicationDbContext context) => _context = context;

        public async Task<List<Domain.Entities.Ingredient>> Handle(CreateIngredientsCommand request, CancellationToken cancellationToken)
        {
            if (50 - _context.Ingredients.Where(x => x.MealId == request.MealId).Count() < -request.Ingredients.Count)
                throw new // need to create new exception about
        }
    }
}