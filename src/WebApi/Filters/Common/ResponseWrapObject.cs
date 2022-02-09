using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Filters.Common
{
    public class ResponseWrapObject
    {
        public bool Success { get; set; }
        public object Value { get; set; }
        public object Error { get; set; }
    }
}