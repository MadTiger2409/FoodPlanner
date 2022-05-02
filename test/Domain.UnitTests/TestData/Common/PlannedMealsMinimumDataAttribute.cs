using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.TestData.Common
{
    public class PlannedMealsMinimumDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new List<Entities.PlannedMeal> { new Entities.PlannedMeal { Id = 1, MealId = 1, OrdinalNumber = 1, ScheduledFor = DateTime.UtcNow.AddDays(2)} }
            };

            yield return new object[]
            {
                new List<Entities.PlannedMeal>
                {
                    new Entities.PlannedMeal {Id = 10, MealId = 458, OrdinalNumber = 4, ScheduledFor = DateTime.UtcNow.AddDays(89)},
                    new Entities.PlannedMeal {Id = 782, MealId = 458, OrdinalNumber = 1, ScheduledFor = DateTime.UtcNow.AddDays(4)},
                    new Entities.PlannedMeal {Id = 58, MealId = 458, OrdinalNumber = 3, ScheduledFor = DateTime.UtcNow.AddDays(26)}
                }
            };
        }
    }
}