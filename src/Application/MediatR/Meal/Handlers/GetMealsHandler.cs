using AutoMapper;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Meal;
using FoodPlanner.Application.MediatR.Meal.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        {
            IQueryable<Domain.Entities.Meal> query = _context.Meals;

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

            return _mapper.Map<List<MealDto>>(await query
                           .Include(x => x.Ingredients).ThenInclude(y => y.Product)
                           .Include(x => x.Ingredients).ThenInclude(y => y.Unit)
                           .ToListAsync());
        }
    }
}