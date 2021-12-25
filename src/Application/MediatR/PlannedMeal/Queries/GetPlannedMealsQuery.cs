﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Queries
{
    public record GetPlannedMealsQuery() : IRequest<List<Domain.Entities.PlannedMeal>>;
}