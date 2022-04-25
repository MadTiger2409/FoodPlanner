using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Meal;
using FoodPlanner.Application.MediatR.Meal.Commands;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class CreateMealWithIngredientsHandler : IRequestHandler<CreateMealWithIngredientsCommand, MealDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreateMealWithIngredientsHandler(IApplicationDbContext dbContext, ISender mediator, IMapper mapper)
        {
            _context = dbContext;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<MealDto> Handle(CreateMealWithIngredientsCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesMealExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var meal = new Domain.Entities.Meal { Name = request.Name };

            meal.Ingredients.AddRange(request.Ingredients);
            _context.Meals.Add(meal);

            await _context.SaveChangesAsync();

            return _mapper.Map<MealDto>(meal);
        }
    }
}