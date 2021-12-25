using FoodPlanner.Application.MediatR.PlannedMeal.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.ActionParameters.PlannedMeal
{
    public class CreatePlannedMeal
    {
        public uint OrdinalNumber { get; set; }
        public DateTime ScheduledFor { get; set; }
        public int MealId { get; set; }

        public CreatePlannedMealCommand GetCreatePlannedMealCommand()
            => new (OrdinalNumber, ScheduledFor, MealId);
    }
}
