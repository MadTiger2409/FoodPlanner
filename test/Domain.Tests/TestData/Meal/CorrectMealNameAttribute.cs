using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.Tests.TestData.Meal
{
    public class CorrectMealNameAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Pieczeń z kluskami śląskimi" };
            yield return new object[] { "Roast with Silesian dumplings" };
            yield return new object[] { "Braten mit Schlesischen Knödeln" };
        }
    }
}