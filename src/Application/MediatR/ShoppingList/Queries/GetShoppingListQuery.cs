using FoodPlanner.Application.Common.ProjectionModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.ShoppingList.Queries
{
    public record GetShoppingListQuery(DateTime From, DateTime To) : IRequest<List<ShoppingListModel>>;
}
