using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Ingredient
{
    public class IngredientValidatorIncorrectAmountData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0.0f };
            yield return new object[] { -0.5f };
            yield return new object[] { -926f };
        }
    }
}
