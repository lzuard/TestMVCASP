using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Infrastructure.Services.Reports;

namespace Presentation.ConsoleHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _service;
        
        public ReportController(ReportService service)
        {
            _service = service;
        }
        
        [HttpGet("getCostOrderAndProductList")]
        public virtual async Task<IActionResult> GetCostOrderAndProductList(CostOrderAndProductListApiParametersDto parameters)
        {
            var result = await _service.TryGetCostOrderAndProductList(parameters);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }
                
        [HttpGet("getSuppliersForPeriod")]
        public virtual async Task<IActionResult> GetSuppliersForPeriod(SuppliersForPeriodApiParametersDto parameters)
        {
            var result = await _service.TryGetSuppliersForPeriod(parameters);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }
        
        [HttpGet("getClientOrderList")]
        public virtual async Task<IActionResult> GetClientOrderList(ClientOrderListApiParametersDto parameters)
        {
            var result = await _service.TryGetClientOrderList(parameters);
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }
        
        [HttpGet("popular")]
        public virtual async Task<IActionResult> GetPopularOrders()
        {
            var result = await _service.TryGetPopularOrders();
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }
    }
}