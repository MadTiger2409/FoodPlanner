﻿using FoodPlanner.WebApi.Filters.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace FoodPlanner.WebApi.Filters
{
	public class ModelStateValidationFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
						.SelectMany(v => v.Errors)
						.Select(v => v.ErrorMessage)
						.ToList();

				var details = new DetailedInformationObject("The uploaded model is invalid", errors);

				context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status400BadRequest };
			}
		}
	}
}