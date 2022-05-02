using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.Tests.TestData.Product
{
    public class CorrectProductNameAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Milk" };
            yield return new object[] { "Gęś" };
            yield return new object[] { "die Würstchen" };
        }
    }
}