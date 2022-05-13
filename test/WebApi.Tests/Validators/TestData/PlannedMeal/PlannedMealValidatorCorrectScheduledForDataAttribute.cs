using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.PlannedMeal
{
    public class PlannedMealValidatorCorrectScheduledForDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { DateTime.UtcNow.Date };
            yield return new object[] { DateTime.UtcNow.Date.AddDays(1) };
            yield return new object[] { DateTime.UtcNow.Date.AddDays(30) };
        }
    }
}
