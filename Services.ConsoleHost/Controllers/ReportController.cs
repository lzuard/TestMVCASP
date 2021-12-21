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
        
        [HttpGet("popular")]
        public virtual async Task<IActionResult> GetPopularOrders()
        {
            var result = await _service.GetPopularOrders();
            
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Error.Message);
        }
    }
}