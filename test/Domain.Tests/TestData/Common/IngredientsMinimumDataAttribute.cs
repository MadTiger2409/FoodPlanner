using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.Tests.TestData.Common
{
    public class IngredientsMinimumDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new List<Entities.Ingredient> {new Entities.Ingredient { Id = 1, Amount = 10} }
            };

            yield return new object[]
            {
                new List<Entities.Ingredient>
                {
                    new Entities.Ingredient { Id = 1, Amount = 9},
                    new Entities.Ingredient { Id = 2, Amount = 123},
                    new Entities.Ingredient { Id = 8, Amount = 75},
                    new Entities.Ingredient { Id = 16, Amount = 46},
                    new Entities.Ingredient { Id = 17, Amount = 53},
                    new Entities.Ingredient { Id = 22, Amount = 98},
                }
            };
        }
    }
}