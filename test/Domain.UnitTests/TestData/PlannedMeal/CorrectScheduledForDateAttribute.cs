using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.TestData.PlannedMeal
{
    public class CorrectScheduledForDateAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { DateTime.UtcNow.Date.AddDays(3) };
            yield return new object[] { DateTime.UtcNow };
            yield return new object[] { DateTime.UtcNow.Date.AddDays(12) };
        }
    }
}