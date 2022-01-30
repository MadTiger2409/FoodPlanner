using AutoMapper;
using FoodPlanner.Application.Common.Exceptions;
using FoodPlanner.Application.Common.Interfaces;
using FoodPlanner.Application.Mappings.Dtos.Product;
using FoodPlanner.Application.MediatR.Category.Queries;
using FoodPlanner.Application.MediatR.Product.Commands;
using FoodPlanner.Application.MediatR.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPlanner.Application.MediatR.Product.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IApplicationDbContext context, ISender mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (product == null)
                throw new EntityNotFoundException(nameof(request.Id));

            if (await _mediator.Send(new DoesCategoryExistByIdQuery(request.CategoryId)) == false)
                throw new EntityNotFoundException(nameof(request.CategoryId));

            if ((product.Name != request.Name) && await _mediator.Send(new DoesProductExistByNameQuery(request.Name)))
                throw new EntityAlreadyExistsException($"{request.Name}");

            product.Name = request.Name;
            product.CategoryId = request.CategoryId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductDto>(product);
        }
    }
}