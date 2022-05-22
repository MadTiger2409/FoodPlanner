using FoodPlanner.WebApi.ActionParameters.Ingredient;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace WebApi.Tests.Validators.TestData.Ingredient
{
    public class IngredientsValidatorIncorrectItemsDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new List<CreateIngredient>
                {
                    new CreateIngredient { ProductId = 0, UnitId = 1, Amount = 1f }
                }
            };

            yield return new object[]
            {
                new List<CreateIngredient>
                {
                    new CreateIngredient { ProductId = 1, UnitId = 0, Amount = 1f }
                }
            };

            yield return new object[]
            {
                new List<CreateIngredient>
                {
                    new CreateIngredient { ProductId = 1, UnitId = 1, Amount = 0f }
                }
            };

            yield return new object[]
            {
                new List<CreateIngredient>
                {
                    new CreateIngredient { ProductId = 0, UnitId = 0, Amount = 0f }
                }
            };

            yield return new object[]
            {
                new List<CreateIngredient>
                {
                    new CreateIngredient { ProductId = 1, UnitId = 1, Amount = 1f },
                    new CreateIngredient { ProductId = 1, UnitId = 1, Amount = 1f },
                    new CreateIngredient { ProductId = 1, UnitId = 1, Amount = 1f },
                    new CreateIngredient { ProductId = 1, UnitId = 0, Amount = 1f },
                    new CreateIngredient { ProductId = 1, UnitId = 1, Amount = 1f },
                    new CreateIngredient { ProductId = 1, UnitId = 1, Amount = 1f }
                }
            };
        }
    }
}
