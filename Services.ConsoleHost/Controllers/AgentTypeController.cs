using Contracts.Contracts.AgentType;
using Presentation.ConsoleHost.Controllers.Base;
using Services.Infrastructure.Services;

namespace Presentation.ConsoleHost.Controllers
{
    public class AgentTypeController : RecordControllerBase<AgentTypeService, AgentTypeDto>
    {
        public AgentTypeController(AgentTypeService service) : base(service)
        {
        }
    }
}