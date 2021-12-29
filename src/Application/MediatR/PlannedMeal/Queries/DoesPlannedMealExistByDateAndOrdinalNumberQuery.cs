using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record DoesPlannedMealExistByDateAndOrdinalNumberQuery(DateTime ScheduledFor, byte OridinalNumber) : IRequest<bool>;
}
