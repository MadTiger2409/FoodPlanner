using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Commands
{
    public record CreatePlannedMealCommand(uint OrdinalNumber, DateTime ScheduledFor, int MealId) : IRequest<Domain.Entities.PlannedMeal>;
}
