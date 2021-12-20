using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Employee;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class EmployeeController : RecordControllerBase<EmployeeService, EmployeeDto>
    {
        public EmployeeController(EmployeeService recordService) : base(recordService)
        {
        }

        [HttpPost("auth")]
        public virtual async Task<IActionResult> Authorization(EmployeeAuthenticationParametersDto parametersDto)
        {
            var result = await Service.TryAuthorization(parametersDto);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest();
        }
    }
}