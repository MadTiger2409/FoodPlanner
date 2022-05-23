using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Category
{
    public class CategoryValidatorIncorrectDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "" };
            yield return new object[] { null };
            yield return new object[] { string.Empty };
            yield return new object[] { "a" };
            yield return new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean mollis lectus nec sapien molestie at." };
        }
    }
}
