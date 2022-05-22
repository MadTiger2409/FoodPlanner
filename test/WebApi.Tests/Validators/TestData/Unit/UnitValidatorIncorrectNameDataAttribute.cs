using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Unit
{
    public class UnitValidatorIncorrectNameDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { "V" };
            yield return new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce porta velit at diam ultricies integer." };
        }
    }
}
