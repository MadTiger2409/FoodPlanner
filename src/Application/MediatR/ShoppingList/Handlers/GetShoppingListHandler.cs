using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Common.ProjectionModels;
using FoodPlanner.Application.MediatR.ShoppingList.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.ShoppingList.Handlers
{
    public class GetShoppingListHandler : IRequestHandler<GetShoppingListQuery, List<ShoppingListModel>>
    {
        private readonly IApplicationDbContext _context;

        public GetShoppingListHandler(IApplicationDbContext context) => _context = context;

        public async Task<List<ShoppingListModel>> Handle(GetShoppingListQuery request, CancellationToken cancellationToken)
        {
            var shoppingList = _context.Ingredients
                .Include(x => x.Product)
                .Include(x => x.Unit)
                .Include(x => x.Meal)
                .ThenInclude(y => y.PlannedMeals.Where(z => z.ScheduledFor.Date >= request.From.Date && z.ScheduledFor.Date <= request.To.Date))
                .GroupBy(b => new
                {
                    Product = b.Product.Name,
                    Unit = b.Unit.Name,
                    b.Id,
                    b.UnitId,
                })
                .Select(sl => new ShoppingListModel
                {
                    Name = sl.Key.Product,
                    Unit = sl.Key.Unit,
                    Amount = sl.Sum(x => x.Amount)
                }).ToList();

            return shoppingList;
        }
    }
}
