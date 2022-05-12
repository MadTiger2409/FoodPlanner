using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.PlannedMeal
{
    public class PlannedMealValidatorCorrectMealIdDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1 };
            yield return new object[] { 85 };
            yield return new object[] { 03675 };
        }
    }
}
