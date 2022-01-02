using FoodPlanner.Application.MediatR.Unit.Commands;
using FoodPlanner.Application.MediatR.Unit.Queries;
using FoodPlanner.WebApi.ActionParameters.Unit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Controllers
{
    [Route("webapi/units")]
    public class UnitController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateUnitAsync([FromBody] CreateUnit command)
        {
            var unit = await Mediator.Send(command.GetCreateUnitCommand());

            return Created($"{Request.Host}{Request.Path}/{unit.Id}", unit);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUnitAsync([FromBody] UpdateUnit command, int id)
        {
            var unit = await Mediator.Send(command.GetUpdateUnitCommand(id));

            return Ok(unit);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUnitAsync(int id)
        {
            var unit = await Mediator.Send(new GetUnitByIdQuery(id));

            return Ok(unit);
        }

        [HttpGet]
        public async Task<IActionResult> GetUnitsAsync()
        {
            var units = await Mediator.Send(new GetUnitsQuery());

            return Ok(units);
        }
    }
}