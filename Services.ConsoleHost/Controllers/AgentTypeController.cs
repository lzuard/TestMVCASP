using System.Threading.Tasks;
using Contracts.Contracts.AgentType;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class AgentTypeController : RecordControllerBase<AgentTypeService, AgentTypeDto>
    {
        public AgentTypeController(AgentTypeService service) : base(service)
        {
        }
        
        public override async Task<IActionResult> Create(AgentTypeDto model)
        {
            return BadRequest(error: "You have no permission");
        }

        public override async Task<IActionResult> Update(AgentTypeDto model)
        {
            return BadRequest(error: "You have no permission");
        }
    }
}