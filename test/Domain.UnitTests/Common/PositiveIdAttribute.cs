using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common
{
    public class PositiveIdAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1 };
            yield return new object[] { 68 };
            yield return new object[] { 976187 };
        }
    }
}