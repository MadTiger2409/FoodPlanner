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
    public class UpdateIngredienthandler : IRequestHandler<UpdateIngredientCommand, Domain.Entities.Ingredient>
    {
        private readonly IApplicationDbContext _context;

        public UpdateIngredienthandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Ingredient> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            /*TODO
                Check if ingredient exists
                Check if ingredient is in relationship with given meal
                Check if product exists
                Check if unit exists
                For each check create Mediator query and handler
             */

            throw new Exception();
        }
    }
}