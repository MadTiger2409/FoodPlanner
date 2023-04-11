using FoodPlanner.Application.MediatR.Category.Commands;
using FoodPlanner.Application.MediatR.Category.Queries;
using FoodPlanner.WebApi.ActionParameters.Category;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
	[Route("webapi/categories")]
	public class CategoryController : ApiControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategory command)
		{
			var category = await Mediator.Send(command.GetCreateCategoryCommand());

			return Created($"{Request.Host}{Request.Path}/{category.Id}", category);
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategory command, int id)
		{
			var category = await Mediator.Send(command.GetUpdateCategoryCommand(id));

			return Ok(category);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteCategoryAsync(int id)
		{
			await Mediator.Send(new DeleteCategoryCommand(id));

			return NoContent();
		}

		[HttpGet("{id:int}")]

		public async Task<IActionResult> GetCategoryAsync(int id)
		{
			var category = await Mediator.Send(new GetCategoryByIdQuery(id));

			return Ok(category);
		}

		[HttpGet]
		public async Task<IActionResult> GetProductsAsync([FromQuery] string name)
		{
			var categories = await Mediator.Send(new GetCategoriesQuery(name));

			return Ok(categories);
		}
	}
}