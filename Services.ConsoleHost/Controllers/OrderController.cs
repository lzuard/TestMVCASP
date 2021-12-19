using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Order;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConsoleHost.Controllers.Base;
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
            OrderFilterParametersDto filterParametersDto)
        {
            var result = await Service.TryGetOrderByFilter(filterParametersDto);

            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return NoContent();
        }
    }
}