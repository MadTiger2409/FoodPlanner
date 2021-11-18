using FoodPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common
{
    public class PlannedMealsMinimumDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new PlannedMeal {Id = 1, MealId = 1, OrdinalNumber = 1, ScheduledFor = DateTime.UtcNow.AddDays(2)}
            };

            yield return new object[]
            {
                new PlannedMeal {Id = 10, MealId = 458, OrdinalNumber = 4, ScheduledFor = DateTime.UtcNow.AddDays(89)}
            };
        }
    }
}