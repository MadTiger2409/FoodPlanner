using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Common.ProjectionModels;
using FoodPlanner.Application.MediatR.ShoppingList.Queries;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace FoodPlanner.Application.MediatR.ShoppingList.Handlers
{
    public class GetShoppingListHandler : IRequestHandler<GetShoppingListQuery, List<ShoppingListModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetShoppingListHandler(IApplicationDbContext context) => _context = context;

        public async Task<List<ShoppingListModel>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            var from = request.From.Date.ToString("s");
            var to = request.To.Date.ToString("s");

            var shoppingList = await _context.ShoppingLists.FromSqlRaw($"SELECT p.Name, u.Name AS 'Unit', SUM(i.amount) AS 'Amount', c.Name AS 'Category' FROM Ingredients i INNER JOIN Meals m ON m.Id = i.MealId INNER JOIN Units u ON u.Id = i.UnitId INNER JOIN PlannedMeals pm ON pm.MealId = m.Id INNER JOIN Products p ON p.Id = i.ProductId INNER JOIN Categories c ON c.Id = p.CategoryId WHERE(pm.ScheduledFor >= CAST('{from}' AS date) and pm.ScheduledFor <= CAST('{to}' AS date)) GROUP BY p.Name, u.Name, c.Name, i.productid, i.unitid, i.mealid;").ToListAsync();

            shoppingList = shoppingList
                .GroupBy(x => new { x.Name, x.Unit, x.Category })
                .Select(y => new ShoppingListModel
                {
                    Name = y.Key.Name,
                    Unit = y.Key.Unit,
                    Amount = Math.Round(y.Sum(s => s.Amount) * request.PeopleCount, 2),
                    Category = y.Key.Category
                })
                .OrderBy(x => x.Category)
                .ThenBy(x => x.Name)
                .ToList();

            return shoppingList;
        }
    }
}