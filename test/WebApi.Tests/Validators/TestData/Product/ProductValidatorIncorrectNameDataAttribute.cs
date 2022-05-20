using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Product
{
    public class ProductValidatorIncorrectNameDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { "a" };
            yield return new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce porta velit at diam ultricies integer." };
        }
    }
}
