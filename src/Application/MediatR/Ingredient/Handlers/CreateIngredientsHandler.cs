using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Ingredient.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class CreateIngredientsHandler : IRequestHandler<CreateIngredientsCommand, List<Domain.Entities.Ingredient>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public CreateIngredientsHandler(IApplicationDbContext context, ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<List<Domain.Entities.Ingredient>> Handle(CreateIngredientsCommand request, CancellationToken cancellationToken)
        {
            var meal = await _mediator.Send(new GetMealByIdQuery(request.MealId));

            // check if there is a duplicated ingredient and then throw exception or do a sum of values

            if (50 - meal.Ingredients.Count < request.Ingredients.Count)
                throw new ArgumentException($"Ingredients list is too long. Meal can't have more than 50 ingredients in total.");

            meal.Ingredients.AddRange(request.Ingredients);
            _context.Meals.Update(meal);

            await _context.SaveChangesAsync();

            return request.Ingredients;
        }
    }
}