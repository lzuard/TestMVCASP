using System.Threading.Tasks;
using Contracts.Contracts.Return;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class ReturnController : RecordControllerBase<ReturnService, ReturnDto>
    {
        public ReturnController(ReturnService service) : base(service)
        {
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ReturnApiDto apiModel)
        {
            var result = await Service.TryCreate(apiModel);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ReturnApiDto apiModel)
        {
            var result = await Service.TryUpdate(apiModel);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NotFound();
        }
    }
}