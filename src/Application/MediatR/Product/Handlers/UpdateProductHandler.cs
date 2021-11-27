using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.MediatR.Product.Commands;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;

        public UpdateProductHandler(IApplicationDbContext context, ISender mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _mediator.Send(new DoesProductExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            var product = await _mediator.Send(new GetProductByIdQuery(request.Id));
            product.Name = request.Name;

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}