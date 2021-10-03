using Application.Common.Interfaces;
using Application.MediatR.Unit.Commands;
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

        public CreateUnitHandler(IApplicationDbContext dbContext) => _context = dbContext;

        public async Task<Domain.Entities.Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = new Domain.Entities.Unit { Name = request.Name };
            _context.Units.Add(unit);

            await _context.SaveChangesAsync(cancellationToken);

            return unit;
        }
    }
}