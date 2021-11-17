using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common.Ingredient
{
    public class InCorrectAmountDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0f };
            yield return new object[] { -0.0000000000000000000001f };
            yield return new object[] { -5.25f };
            yield return new object[] { -1084f };
        }
    }
}