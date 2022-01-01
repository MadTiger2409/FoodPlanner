using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Ingredient;
using FoodPlanner.Application.MediatR.Ingredient.Commands;
using FoodPlanner.Application.MediatR.Ingredient.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Ingredient.Handlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredientCommand, IngredientDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UpdateIngredientHandler(IApplicationDbContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IngredientDto> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CanUpdateIngredientQuery(request.UnitId, request.ProductId, request.MealId, request.IngredientId));

            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(x => x.Id == request.IngredientId);

            ingredient.ProductId = request.ProductId;
            ingredient.UnitId = request.UnitId;
            ingredient.Amount = request.Amount;

            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();

            return _mapper.Map<IngredientDto>(ingredient);
        }
    }
}