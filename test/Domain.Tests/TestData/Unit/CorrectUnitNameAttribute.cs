using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.Tests.TestData.Unit
{
    public class CorrectUnitNameAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "ml" };
            yield return new object[] { "mililitr" };
            yield return new object[] { "der Liter" };
            yield return new object[] { "piece" };
            yield return new object[] { "sztuka" };
            yield return new object[] { "das Stück" };
        }
    }
}