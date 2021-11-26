﻿using FoodPlanner.Application.MediatR.Meal.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/meals")]
    public class MealController : ApiControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMealByIdAsync(int id)
        {
            var meal = await Mediator.Send(new GetMealByIdQuery(id));

            return Ok(meal);
        }

        [HttpGet]
        public async Task<IActionResult> GetMealsAsync()
        {
            var meals = await Mediator.Send(new GetMealsQuery());

            return Ok(meals);
        }
    }
}