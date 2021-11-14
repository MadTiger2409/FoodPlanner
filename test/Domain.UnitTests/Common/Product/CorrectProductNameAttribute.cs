using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common.Product
{
    public class CorrectProductNameAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Milk" };
            yield return new object[] { "Gęś" };
            yield return new object[] { "die Würstchen" };
        }
    }
}