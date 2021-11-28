using FoodPlanner.WebApi.ActionParameters.Ingredient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/meals/{id}/ingredients")]
    public class IngredientController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateIngredientsAsync([FromBody] List<CreateIngredient> command, int id)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIngredientAsync([FromBody] UpdateIngredient command, int id)
        {
            throw new Exception();
        }
    }
}