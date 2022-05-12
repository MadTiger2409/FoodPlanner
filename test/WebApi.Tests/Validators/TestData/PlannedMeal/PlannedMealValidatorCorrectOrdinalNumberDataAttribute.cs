using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.PlannedMeal
{
    public class PlannedMealValidatorCorrectOrdinalNumberDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { (byte)1 };
            yield return new object[] { (byte)97 };
            yield return new object[] { (byte)125 };
            yield return new object[] { (byte)255 };
        }
    }
}
