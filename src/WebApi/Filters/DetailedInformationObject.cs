using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Filters
{
    public class DetailedInformationObject
    {
        public string Title { get; set; }
        public List<string> Details { get; set; }

        public DetailedInformationObject(string title)
        {
            Title = title;
            Details = new List<string>();
        }

        public DetailedInformationObject(string title, string detail) : this(title) => Details.Add(detail);

        public DetailedInformationObject(string title, List<string> details) : this(title) => Details = details;
    }
}