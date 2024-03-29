﻿using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using FoodPlanner.WebApi.ActionParameters.Meal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
	[Route("webapi/meals")]
	public class MealController : ApiControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreateMealAsync([FromBody] CreateMealWithIngredients command)
		{
			var meal = await Mediator.Send(command.GetCreateMealWithIngredientsCommand());

			return Created($"{Request.Host}{Request.Path}/{meal.Id}", meal);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateMealAsync([FromBody] UpdateMeal command, int id)
		{
			var meal = await Mediator.Send(command.GetUpdateMealCommand(id));

			return Ok(meal);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteMealAsync(int id)
		{
			await Mediator.Send(new DeleteMealCommand(id));

			return NoContent();
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetMealByIdAsync(int id)
		{
			var meal = await Mediator.Send(new GetMealByIdQuery(id));

			return Ok(meal);
		}

		[HttpGet]
		public async Task<IActionResult> GetMealsAsync([FromQuery] string name)
		{
			var meals = await Mediator.Send(new GetMealsQuery(name));

			return Ok(meals);
		}
	}
}