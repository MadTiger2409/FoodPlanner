using FoodPlanner.Application.Common.ProjectionModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
	public record GetPlannedMealsQuery(DateTime From, DateTime To) : IRequest<List<PlannedMealsGroupModel>>;
}