using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Ingredient
{
    public class IngredientValidatorCorrectProductIdDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1 };
            yield return new object[] { 75 };
            yield return new object[] { 68676826 };
        }
    }
}
