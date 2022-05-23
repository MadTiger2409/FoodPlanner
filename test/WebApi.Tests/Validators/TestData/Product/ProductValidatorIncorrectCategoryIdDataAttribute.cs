using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Product
{
    public class ProductValidatorIncorrectCategoryIdDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0 };
            yield return new object[] { -785 };
        }
    }
}
