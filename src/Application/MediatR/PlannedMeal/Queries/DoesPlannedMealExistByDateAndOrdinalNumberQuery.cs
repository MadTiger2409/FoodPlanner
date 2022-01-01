using MediatR;
using System;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record DoesPlannedMealExistByDateAndOrdinalNumberQuery(DateTime ScheduledFor, byte OridinalNumber) : IRequest<bool>;
}
