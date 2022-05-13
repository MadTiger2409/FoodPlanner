using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.PlannedMeal
{
    public class PlannedMealValidatorIncorrectScheduledForDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { DateTime.UtcNow.Date.AddDays(-1) };
        }
    }
}
