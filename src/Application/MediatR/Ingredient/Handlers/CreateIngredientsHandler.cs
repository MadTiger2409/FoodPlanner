using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Ingredient;
using FoodPlanner.Application.MediatR.Ingredient.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using FoodPlanner.Domain.Comparers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class CreateIngredientsHandler : IRequestHandler<CreateIngredientsCommand, List<IngredientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateIngredientsHandler(IApplicationDbContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IngredientDto>> Handle(CreateIngredientsCommand request, CancellationToken cancellationToken)
        {
            var meal = await _context.Meals
                .Include(x => x.Ingredients).ThenInclude(y => y.Product)
                .Include(x => x.Ingredients).ThenInclude(y => y.Unit)
                .SingleOrDefaultAsync(x => x.Id == request.MealId);

            if (meal == null)
                throw new EntityNotFoundException(nameof(request.MealId));

            var duplicates = meal.Ingredients.Intersect(request.Ingredients, new IngredientWithoutAmountComparer());

            if (duplicates.Any())
                throw new ArgumentException($"Meal can't have duplicated ingredients.");

            if (50 - meal.Ingredients.Count < request.Ingredients.Count)
                throw new ArgumentException($"Ingredients list is too long. Meal can't have more than 50 ingredients in total.");

            meal.Ingredients.AddRange(request.Ingredients);
            _context.Meals.Update(meal);

            await _context.SaveChangesAsync();

            return _mapper.Map<List<IngredientDto>>(request.Ingredients);
        }
    }
}