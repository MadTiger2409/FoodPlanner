﻿using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.PlannedMeal.Commands;
using FoodPlanner.Application.MediatR.PlannedMeal.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.PlannedMeal.Handlers
{
    public class CreatePlannedMealHandler : IRequestHandler<CreatePlannedMealCommand, Domain.Entities.PlannedMeal>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public CreatePlannedMealHandler(IApplicationDbContext context, ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public Task<Domain.Entities.PlannedMeal> Handle(CreatePlannedMealCommand request, CancellationToken cancellationToken)
        {
            _mediator.Send(new CanCreatePlannedMealQuery(request.MealId, request.OrdinalNumber, request.ScheduledFor));
        }
    }
}