using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Order;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class OrderController : RecordControllerBase<OrderService, OrderDto>
    {
        public OrderController(OrderService service) : base(service)
        {
        }

        [HttpGet("getByFilter")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderByFilter(
            OrderFilterDto filterDto)
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