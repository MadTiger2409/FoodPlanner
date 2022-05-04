using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Ingredient
{
    public class IngredientValidatorCorrectAmountDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0.02f };
            yield return new object[] { 2f };
            yield return new object[] { 572.25f };
        }
    }
}
