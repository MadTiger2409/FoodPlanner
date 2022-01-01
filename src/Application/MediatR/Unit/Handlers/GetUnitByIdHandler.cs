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
    public class GetUnitByIdHandler : IRequestHandler<GetUnitByIdQuery, UnitDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUnitByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UnitDto> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            var unit = await _context.Units.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (unit == null)
                throw new EntityNotFoundException(nameof(request.Id));

            return _mapper.Map<UnitDto>(unit);
        }
    }
}