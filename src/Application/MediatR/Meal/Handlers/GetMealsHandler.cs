using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Meal;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Meal.Handlers
{
    public class GetMealsHandler : IRequestHandler<GetMealsQuery, List<MealDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMealsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MealDto>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
            => _mapper.Map<List<MealDto>>(await _context.Meals
                .Include(x => x.Ingredients).ThenInclude(y => y.Product)
                .Include(x => x.Ingredients).ThenInclude(y => y.Unit)
                .ToListAsync());
    }
}