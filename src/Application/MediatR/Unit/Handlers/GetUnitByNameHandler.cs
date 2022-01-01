using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Unit;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class GetUnitByNameHandler : IRequestHandler<GetUnitByNameQuery, UnitDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUnitByNameHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UnitDto> Handle(GetUnitByNameQuery request, CancellationToken cancellationToken)
        {
            var unit = await _context.Units.SingleOrDefaultAsync(x => x.Name.ToLowerInvariant().Equals(request.Name.ToLowerInvariant()));

            if (unit == null)
                throw new EntityNotFoundException(nameof(request.Name));

            return _mapper.Map<UnitDto>(unit);
        }
    }
}