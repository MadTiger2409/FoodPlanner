using FoodPlanner.Application.MediatR.Meal.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class CreateMealHandler : IRequestHandler<CreateMealCommand, Domain.Entities.Meal>
    {
        public Task<Domain.Entities.Meal> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}