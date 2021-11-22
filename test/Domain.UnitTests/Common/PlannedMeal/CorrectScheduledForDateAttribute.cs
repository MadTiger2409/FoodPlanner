using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common.PlannedMeal
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