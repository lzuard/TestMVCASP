using Contracts.Contracts.AgentType;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;

namespace Services.Infrastructure.Services
{
    public class AgentTypeService : ServiceBase<AgentTypeRepository, AgentTypeDto>
    {
        public AgentTypeService(AgentTypeRepository recordRepository) : base(recordRepository)
        {
        }
    }
}