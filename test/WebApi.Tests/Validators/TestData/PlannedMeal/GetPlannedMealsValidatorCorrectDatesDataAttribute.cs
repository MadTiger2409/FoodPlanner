using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.PlannedMeal
{
    public class GetPlannedMealsValidatorCorrectDatesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { DateTime.UtcNow.Date, DateTime.UtcNow.Date };
            yield return new object[] { DateTime.UtcNow.Date, DateTime.UtcNow.AddDays(1).Date };
            yield return new object[] { DateTime.UtcNow.Date, DateTime.UtcNow.AddDays(31).Date };
            yield return new object[] { DateTime.UtcNow.AddDays(2).Date, DateTime.UtcNow.AddDays(10).Date };
        }
    }
}
