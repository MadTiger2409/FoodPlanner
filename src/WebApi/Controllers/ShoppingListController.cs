using FoodPlanner.Application.MediatR.ShoppingList.Queries;
using FoodPlanner.Infrastructure.Persistence.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/shoppingList")]
    public class ShoppingListController : ApiControllerBase
    {
        private IShoppingListPdfGenerator _pdfGenerator;

        public ShoppingListController(IShoppingListPdfGenerator pdfGenerator) : base()
        {
            _pdfGenerator = pdfGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> GetShoppingListAsync(DateTime from, DateTime to, float peopleCount)
        {
            if (peopleCount == 0f)
                peopleCount = 1f;

            var shoppingList = await Mediator.Send(new GetShoppingListQuery(from, to, peopleCount));

            return Ok(shoppingList);
        }

        [HttpGet("pdf")]
        public async Task<IActionResult> GetShoppingListAsPdf(DateTime from, DateTime to, float peopleCount)
        {
            if (peopleCount == 0f)
                peopleCount = 1f;

            var shoppingList = await Mediator.Send(new GetShoppingListQuery(from, to, peopleCount));
            var pdf = _pdfGenerator.GetPdf(shoppingList);

            return File(pdf.Content, pdf.Type, pdf.Name);
        }
    }
}