using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using System;

namespace FoodPlanner.WebApi.ActionParameters.PlannedMeal
{
    public class GetPlannedMeals
    {
        public DateTime From { get; set; } = DateTime.UtcNow.Date;
        public DateTime To { get; set; } = DateTime.UtcNow.Date;

        public GetPlannedMealsQuery GetGetPlannedMealsQuery()
            => new(From, To);
    }
}