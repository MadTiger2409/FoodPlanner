using FoodPlanner.Application.MediatR.Product.Commands;
using FoodPlanner.Application.MediatR.Product.Queries;
using FoodPlanner.WebApi.ActionParameters.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/products")]
    public class ProductController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProduct command)
        {
            var product = await Mediator.Send(command.GetCreateProductCommand());

            return Created($"{Request.Host}{Request.Path}/{product.Id}", product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProduct command, int id)
        {
            var product = await Mediator.Send(command.GetUpdateProductCommand(id));

            return Ok(product);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var product = await Mediator.Send(new GetProductByIdQuery(id));

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await Mediator.Send(new GetProductsQuery());

            return Ok(products);
        }
    }
}