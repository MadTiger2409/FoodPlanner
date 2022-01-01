using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Meal;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class GetMealByIdHandler : IRequestHandler<GetMealByIdQuery, MealDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMealByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MealDto> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await _context.Meals
                                .Include(x => x.Ingredients).ThenInclude(y => y.Product)
                                .Include(x => x.Ingredients).ThenInclude(y => y.Unit)
                                .SingleOrDefaultAsync(x => x.Id == request.Id);

            if (meal == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return _mapper.Map<MealDto>(meal);
        }
    }
}