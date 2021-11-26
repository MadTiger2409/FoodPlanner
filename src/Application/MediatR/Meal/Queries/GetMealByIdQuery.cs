using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Queries
{
    public record GetMealByIdQuery(int Id) : IRequest<Domain.Entities.Meal>;
}