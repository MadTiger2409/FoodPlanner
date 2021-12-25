using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record GetPlannedMealByIdQuery(int Id) : IRequest<Domain.Entities.PlannedMeal>;
}
