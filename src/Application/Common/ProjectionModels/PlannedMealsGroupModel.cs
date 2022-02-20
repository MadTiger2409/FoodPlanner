using FoodPlanner.Application.Mappings.Dtos.PlannedMeal;
using System;
using System.Collections.Generic;

namespace FoodPlanner.Application.Common.ProjectionModels
{
    public class PlannedMealsGroupModel
    {
        public DateTime ScheduledFor { get; set; }
        public List<PlannedMealForGroupingDto> PlannedMeals { get; set; }
    }
}