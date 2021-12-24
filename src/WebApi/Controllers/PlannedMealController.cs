using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
