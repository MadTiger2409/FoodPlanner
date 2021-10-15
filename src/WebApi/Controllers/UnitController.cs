using FoodPlanner.Application.MediatR.Unit.Commands;
using FoodPlanner.WebApi.ActionParameters.Unit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("units")]
    public class UnitController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUnitAsync([FromBody] CreateUnit @params)
        {
            var unit = await Mediator.Send(new CreateUnitCommand(@params.Name));

            return Created($"{Request.Host}{Request.Path}/{unit.Id}", unit);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUnitAsync([FromBody] UpdateUnit @params, int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUnitAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}