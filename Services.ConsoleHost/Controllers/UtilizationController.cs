using System.Threading.Tasks;
using Contracts.Contracts.Utilization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class UtilizationController : RecordControllerBase<UtilizationService, UtilizationDto>
    {
        public UtilizationController(UtilizationService service) : base(service)
        {
        }
        
        public override async Task<IActionResult> Create(UtilizationDto model)
        {
            return BadRequest(error:"You have no permission");
        }

        public override async Task<IActionResult> Update(UtilizationDto model)
        {
            return BadRequest(error:"You have no permission");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UtilizationApiDto apiModel)
        {
            var result = await Service.TryCreate(apiModel);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UtilizationApiDto apiModel)
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