using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Product
{
    public class ProductValidatorCorrectCategoryIdDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1 };
            yield return new object[] { 7895 };
        }
    }
}
