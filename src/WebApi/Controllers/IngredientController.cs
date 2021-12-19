using FoodPlanner.Application.MediatR.Ingredient.Commands;
using FoodPlanner.WebApi.ActionParameters.Ingredient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/meals/{id}/ingredients")]
    public class IngredientController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateIngredientsAsync([FromBody] List<CreateIngredient> command, int id)
        {
            var ingredients = await Mediator.Send(new CreateIngredientsCommand(id, command.Select(a => (Domain.Entities.Ingredient)a).ToList()));

            return Created($"{Request.Host}{Request.Path}/", ingredients);
        }

        [HttpPut("{ingredientId}")]
        public async Task<IActionResult> UpdateIngredientAsync([FromBody] UpdateIngredient command, int id, int ingredientId)
        {
            var mediatorCommand = (UpdateIngredientCommand)command;
            mediatorCommand.MealId = id;
            mediatorCommand.IngredientId = ingredientId;

            var ingredient = await Mediator.Send(mediatorCommand);

            return Ok(ingredient);
        }
    }
}