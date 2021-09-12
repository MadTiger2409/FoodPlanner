﻿using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Unit : NamedEntity
    {
        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}