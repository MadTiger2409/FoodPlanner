using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class GetPlannedMealsHandler : IRequestHandler<GetPlannedMealsQuery, List<Domain.Entities.PlannedMeal>>
    {
        public Task<List<Domain.Entities.PlannedMeal>> Handle(GetPlannedMealsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
