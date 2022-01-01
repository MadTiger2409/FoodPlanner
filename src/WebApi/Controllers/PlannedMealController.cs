using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using FoodPlanner.WebApi.ActionParameters.PlannedMeal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/plannedMeals")]
    public class PlannedMealController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPlannedMealsAsync()
        {
            var plannedMeals = await Mediator.Send(new GetPlannedMealsQuery());

            return Ok(plannedMeals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlannedMealByIdAsync(int id)
        {
            var plannedMeal = await Mediator.Send(new GetPlannedMealByIdQuery(id));

            return Ok(plannedMeal);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlannedMealAsync([FromBody] CreatePlannedMeal command)
        {
            var plannedMeal = await Mediator.Send(command.GetCreatePlannedMealCommand());

            return Created($"{Request.Host}{Request.Path}/{plannedMeal.Id}", plannedMeal);
        }
    }
}
