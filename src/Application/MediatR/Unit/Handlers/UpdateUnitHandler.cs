using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Unit;
using FoodPlanner.Application.MediatR.Unit.Commands;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class UpdateUnitHandler : IRequestHandler<UpdateUnitCommand, UnitDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UpdateUnitHandler(IApplicationDbContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UnitDto> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesUnitExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var unit = await _context.Units.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (unit == null)
                throw new EntityNotFoundException(nameof(request.Id));

            unit.Name = request.Name;

            _context.Units.Update(unit);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UnitDto>(unit);
        }
    }
}