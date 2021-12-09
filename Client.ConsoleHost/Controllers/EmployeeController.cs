using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Records;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.SearchParameters;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class EmployeeController : RecordControllerBase<EmployeeService, EmployeeRecordDto>
    {
        public EmployeeController(EmployeeService recordService,
            ILogger<RecordControllerBase<EmployeeService, EmployeeRecordDto>> logger) : base(recordService, logger)
        {
        }
        
        [HttpPost ("{employeeLoginSearchParameters}")]
        public virtual async Task<ActionResult<IEnumerable<bool>>> Authorization(string employeeLoginSearchParameters)
        {
            EmployeeLoginSearchParameters employeeLoginAndPassword;
            
            try
            {
                employeeLoginAndPassword = JsonConvert.DeserializeObject<EmployeeLoginSearchParameters>(employeeLoginSearchParameters);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            var result = await Service.TryAuthorization(employeeLoginAndPassword);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            
            Logger.LogError(result.Error.Message);

            return BadRequest();
        }
    }
}