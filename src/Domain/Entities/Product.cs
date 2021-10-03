using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product : NamedEntity
    {
        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}