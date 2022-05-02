using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.TestData.Ingredient
{
    public class CorrectAmountDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 0.5f };
            yield return new object[] { 3.5f };
            yield return new object[] { 32f };
            yield return new object[] { 200f };
        }
    }
}