using FoodPlanner.Application.MediatR.ShoppingList.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/shoppingList")]
    public class ShoppingListController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetShoppingListAsync(DateTime from, DateTime to)
        {
            var shoppingList = await Mediator.Send(new GetShoppingListQuery(from, to));

            return Ok(shoppingList);
        }
    }
}
