using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Unit;
using FoodPlanner.Application.MediatR.Unit.Commands;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, UnitDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreateUnitHandler(IApplicationDbContext dbContext, ISender mediator, IMapper mapper)
        {
            _context = dbContext;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UnitDto> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesUnitExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var unit = new Domain.Entities.Unit { Name = request.Name };
            _context.Units.Add(unit);

            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UnitDto>(unit);
        }
    }
}