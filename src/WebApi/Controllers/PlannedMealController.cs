using FoodPlanner.Application.MediatR.PlannedMeal.Commands;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
	[Route("webapi/plannedMeals")]
	public class PlannedMealController : ApiControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreatePlannedMealAsync([FromBody] CreatePlannedMeal command)
		{
			var plannedMeal = await Mediator.Send(command.GetCreatePlannedMealCommand());

			return Created($"{Request.Host}{Request.Path}/{plannedMeal.Id}", plannedMeal);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeletePlannedMealAsync(int id)
		{
			await Mediator.Send(new DeletePlannedMealCommand(id));

			return NoContent();
		}

		[HttpGet]
		public async Task<IActionResult> GetPlannedMealsAsync([FromQuery] GetPlannedMeals command)
		{
			var plannedMeals = await Mediator.Send(command.GetGetPlannedMealsQuery());

			return Ok(plannedMeals);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetPlannedMealByIdAsync(int id)
		{
			var plannedMeal = await Mediator.Send(new GetPlannedMealByIdQuery(id));

			return Ok(plannedMeal);
		}
	}
}