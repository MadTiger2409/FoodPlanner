using FoodPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FoodPlanner.Domain.Comparers
{
    public class IngredientWithoutAmountComparer : IEqualityComparer<Ingredient>
    {
        public bool Equals(Ingredient x, Ingredient y) => x.ProductId == y.ProductId && x.UnitId == y.UnitId;

        public int GetHashCode([DisallowNull] Ingredient obj) => obj.ProductId.GetHashCode() ^ obj.UnitId.GetHashCode();
    }
}