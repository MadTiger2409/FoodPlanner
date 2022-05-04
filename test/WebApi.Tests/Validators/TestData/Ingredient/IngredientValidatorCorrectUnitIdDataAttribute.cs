using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Ingredient
{
    public class IngredientValidatorCorrectUnitIdDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 3 };
            yield return new object[] { 59 };
            yield return new object[] { 9526057 };
        }
    }
}
