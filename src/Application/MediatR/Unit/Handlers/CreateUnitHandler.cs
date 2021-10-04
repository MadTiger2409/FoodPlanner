using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.MediatR.Unit.Commands;
using Application.MediatR.Unit.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.MediatR.Unit.Handlers
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
            var unit = await _mediator.Send(new GetUnitByNameQuery(request.Name));

            if (unit != null)
                throw new EntityAlreadyExistsException("Unit");

            unit = new Domain.Entities.Unit { Name = request.Name };
            _context.Units.Add(unit);

            await _context.SaveChangesAsync(cancellationToken);

            return unit;
        }
    }
}