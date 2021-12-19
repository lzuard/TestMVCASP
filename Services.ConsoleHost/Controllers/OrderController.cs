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
    public class OrderController : RecordControllerBase<OrderService, OrderRecordDto>
    {
        public OrderController(OrderService service) : base(service)
        {
        }

        [HttpGet("special/{jsonFilterParameters}")]
        public async Task<ActionResult<IEnumerable<OrderRecordDto>>> GetOrderByFilter(
            string jsonFilterParameters)
        {
            OrderSearchParameters filterParameters;

            try
            {
                filterParameters = JsonConvert.DeserializeObject<OrderSearchParameters>(jsonFilterParameters);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            var result = await Service.TryGetOrderByFilter(filterParameters);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }
    }
}