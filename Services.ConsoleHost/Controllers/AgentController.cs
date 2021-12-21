using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Agent;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class AgentController : RecordControllerBase<AgentService, AgentDto>
    {
        public AgentController(AgentService service) : base(service)
        {
        }

        public override async Task<IActionResult> Create(AgentDto model)
        {
            return BadRequest(error: "You have no permission");
        }

        public override async Task<IActionResult> Update(AgentDto model)
        {
            return BadRequest(error: "You have no permission");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AgentApiDto apiModel)
        {
            var result = await Service.TryCreate(apiModel);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(AgentApiDto apiModel)
        {
            var result = await Service.TryUpdate(apiModel);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NotFound();
        }

        [HttpPost("getByFilter")]
        public async Task<ActionResult<IEnumerable<AgentDto>>> GetOrderByFilter(AgentFilterDto filterDto)
        {
            var result = await Service.TryGetOrderByFilter(filterDto);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }
    }
}