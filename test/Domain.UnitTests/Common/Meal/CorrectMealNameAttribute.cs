using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common.Meal
{
    public class CorrectMealNameAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Pieczeń z kluskami śląskimi" };
            yield return new object[] { "Roast with Silesian dumplings" };
            yield return new object[] { "Braten mit Schlesischen Knödeln" };
        }
    }
}