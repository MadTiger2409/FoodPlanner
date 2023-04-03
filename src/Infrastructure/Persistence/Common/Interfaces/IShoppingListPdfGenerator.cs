using FoodPlanner.Application.Common.ProjectionModels;
using System.Collections.Generic;

namespace FoodPlanner.Infrastructure.Persistence.Common.Interfaces
{
	public interface IShoppingListPdfGenerator
    {
        public FileResult GetPdf(List<ShoppingListModel> shoppingList);
    }
}