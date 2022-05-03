using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Category
{
    public class CategoryValidatorCorrectDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "fruits and vegetables" };
            yield return new object[] { "konserwy" };
            yield return new object[] { "Nudeln, Reis und Grütze" };
        }
    }
}
