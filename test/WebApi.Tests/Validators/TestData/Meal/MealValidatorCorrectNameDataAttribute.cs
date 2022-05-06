using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Meal
{
    public class MealValidatorCorrectNameDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Pie" };
            yield return new object[] { "Apple pie with crunchy base and chocolate" };
            yield return new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec hendrerit augue vitae neque eleifend, at laoreet velit pulvinar. Integer finibus, tellus eget consequat ullamcorper, nibh massa mollis mi, a facilisis dui arcu ac sem. Curabitur vel varius risus. Donec non laoreet sapien. Cras lectus leo" };
        }
    }
}
