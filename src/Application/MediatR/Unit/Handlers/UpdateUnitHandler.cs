using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Commands;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class UpdateUnitHandler : IRequestHandler<UpdateUnitCommand, Domain.Entities.Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public UpdateUnitHandler(IApplicationDbContext context, ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Unit> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesUnitExistsByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var unit = await _mediator.Send(new GetUnitByIdQuery(request.Id));
            unit.Name = request.Name;

            _context.Units.Update(unit);
            await _context.SaveChangesAsync(cancellationToken);

            return unit;
        }
    }
}