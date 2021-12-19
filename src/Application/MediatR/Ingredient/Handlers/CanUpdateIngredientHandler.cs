using FoodPlanner.Application.MediatR.Ingredient.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class CanUpdateIngredientHandler : IRequestHandler<CanUpdateIngredientQuery>
    {
        public async Task<global::MediatR.Unit> Handle(CanUpdateIngredientQuery request, CancellationToken cancellationToken)
        {
            return global::MediatR.Unit.Value;
        }
    }
}