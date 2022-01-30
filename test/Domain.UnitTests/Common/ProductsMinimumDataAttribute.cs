using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace FoodPlanner.Domain.UnitTests.Common
{
    class ProductsMinimumDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new List<Entities.Product> {new Entities.Product { Id = 1, Name = "apple", CategoryId = 1 }}
            };

            yield return new object[]
            {
                new List<Entities.Product>
                {
                    new Entities.Product {Id = 4, Name = "orange", CategoryId = 1 },
                    new Entities.Product {Id = 15, Name = "onion", CategoryId = 2 },
                    new Entities.Product {Id = 10, Name = "mleko", CategoryId = 3 },
                    new Entities.Product {Id = 87, Name = "łosoś", CategoryId = 12 }
                }
            };
        }
    }
}
