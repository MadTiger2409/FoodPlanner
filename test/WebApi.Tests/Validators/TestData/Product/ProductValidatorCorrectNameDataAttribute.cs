using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Product
{
    public class ProductValidatorCorrectNameDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Pi" };
            yield return new object[] { "Tomato" };
            yield return new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce porta velit at diam ultricies integer" };
        }
    }
}
