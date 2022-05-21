using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Unit
{
    public class UnitValidatorCorrectNameDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Va" };
            yield return new object[] { "Vegetables and fruits" };
            yield return new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce porta velit at diam ultricies integer" };
        }
    }
}
