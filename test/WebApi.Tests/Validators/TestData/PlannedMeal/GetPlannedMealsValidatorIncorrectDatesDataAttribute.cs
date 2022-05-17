using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.PlannedMeal
{
    public class GetPlannedMealsValidatorIncorrectDatesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { DateTime.UtcNow.Date, DateTime.UtcNow.AddDays(-1).Date };
            yield return new object[] { DateTime.UtcNow.AddDays(12).Date, DateTime.UtcNow.Date };
            yield return new object[] { DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(32) };
        }
    }
}
