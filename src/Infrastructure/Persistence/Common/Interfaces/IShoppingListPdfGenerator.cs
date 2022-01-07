using FoodPlanner.Application.Common.ProjectionModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Infrastructure.Persistence.Common.Interfaces
{
    public interface IShoppingListPdfGenerator
    {
        public FileResult GetPdf(List<ShoppingListModel> shoppingList);
    }
}