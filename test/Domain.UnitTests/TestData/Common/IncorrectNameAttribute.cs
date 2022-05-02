using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.TestData.Common
{
    public class IncorrectNameAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { null };
            yield return new object[] { "    " };
            yield return new object[] { string.Empty };
        }
    }
}