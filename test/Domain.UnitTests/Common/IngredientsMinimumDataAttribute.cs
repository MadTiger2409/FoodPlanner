using FoodPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common
{
    public class IngredientsMinimumDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new List<Ingredient> {new Ingredient { Id = 1, Amount = 10} }
            };

            yield return new object[]
            {
                new List<Ingredient>
                {
                    new Ingredient { Id = 1, Amount = 9},
                    new Ingredient { Id = 2, Amount = 123},
                    new Ingredient { Id = 8, Amount = 75},
                    new Ingredient { Id = 16, Amount = 46},
                    new Ingredient { Id = 17, Amount = 53},
                    new Ingredient { Id = 22, Amount = 98},
                }
            };
        }
    }
}