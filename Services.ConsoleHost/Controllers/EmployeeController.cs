using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Records;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.SearchParameters;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class EmployeeController : RecordControllerBase<EmployeeService, EmployeeRecordDto>
    {
        public EmployeeController(EmployeeService recordService) : base(recordService)
        {
        }

        [HttpPost("auth")]
        public virtual async Task<ActionResult<IEnumerable<bool>>> Authorization(
            EmployeeLoginSearchParameters parameters)
        {
            var result = await Service.TryAuthorization(parameters);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest();
        }
    }
}