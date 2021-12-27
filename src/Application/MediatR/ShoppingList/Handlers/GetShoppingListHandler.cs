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
            throw new NotImplementedException();
        }
    }
}
