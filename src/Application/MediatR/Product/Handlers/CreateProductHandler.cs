using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Commands;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public CreateProductHandler(IApplicationDbContext dbContext, ISender mediator)
        {
            _context = dbContext;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesProductExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var product = new Domain.Entities.Product { Name = request.Name };
            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}