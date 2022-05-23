using FoodPlanner.WebApi.ActionParameters.Ingredient;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Ingredient
{
    public class IngredientsValidatorCorrectItemsDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new List<CreateIngredient>
                {
                    new CreateIngredient {ProductId = 1, UnitId = 1, Amount = 0.5f}
                }
            };

            yield return new object[]
            {
                new List<CreateIngredient>
                {
                    new CreateIngredient {ProductId = 1, UnitId = 1, Amount = 0.5f},
                    new CreateIngredient {ProductId = 95, UnitId = 121, Amount = 95.86f},
                    new CreateIngredient {ProductId = 762, UnitId = 91, Amount = 9f},
                    new CreateIngredient {ProductId = 9422, UnitId = 2, Amount = 821f},
                    new CreateIngredient {ProductId = 9422, UnitId = 2, Amount = 821f}
                }
            };
        }
    }
}
