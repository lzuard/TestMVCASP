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

        [HttpGet("getByFilter")]
        public async Task<ActionResult<IEnumerable<OrderRecordDto>>> GetOrderByFilter(
            OrderSearchParameters filterParameters)
        {
            var result = await Service.TryGetOrderByFilter(filterParameters);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }
    }
}