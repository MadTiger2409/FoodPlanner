using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Unit.Commands;
using FoodPlanner.Application.MediatR.Unit.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Unit.Handlers
{
    public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, Domain.Entities.Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public CreateUnitHandler(IApplicationDbContext dbContext, ISender mediator)
        {
            _context = dbContext;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesUnitExistsByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException("Unit");

            var unit = new Domain.Entities.Unit { Name = request.Name };
            _context.Units.Add(unit);

            await _context.SaveChangesAsync(cancellationToken);

            return unit;
        }
    }
}