using FoodPlanner.Application.MediatR.Unit.Commands;
using FoodPlanner.Application.MediatR.Unit.Queries;
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
            var unit = await Mediator.Send(new UpdateUnitCommand(id, @params.Name));

            return Ok(unit);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUnitAsync(int id)
        {
            var unit = await Mediator.Send(new GetUnitByIdQuery(id));

            return Ok(unit);
        }
    }
}