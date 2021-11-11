using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common.Product
{
    public class CorrectDataWithoutIngredientsAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                1,
                "Milk"
            };
        }
    }
}