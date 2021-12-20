using Contracts.Contracts.AgentType;
using Data.LTS.Database;
using Services.Infrastructure.Repositories.Base;

namespace Services.Infrastructure.Repositories
{
    public class AgentTypeRepository : RepositoryBase<AgentTypeDto>
    {
        public AgentTypeRepository(ApplicationContext context) : base(context)
        {
        }
    }
}