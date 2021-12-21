using MediatR;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.Meal.Queries
{
    public record GetMealsQuery : IRequest<IList<Domain.Entities.Meal>>;
}