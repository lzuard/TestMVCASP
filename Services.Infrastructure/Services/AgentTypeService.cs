using System.Threading.Tasks;
using Contracts.Contracts.AgentType;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class AgentTypeService : ServiceBase<AgentTypeRepository, AgentTypeDto>
    {
        public AgentTypeService(AgentTypeRepository recordRepository) : base(recordRepository)
        {
        }

        public override Task<OperationResult<AgentTypeDto>> TryUpdate(AgentTypeDto model)
        {
            string message = "You have no permission";
            
            var result = OperationResult<AgentTypeDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<AgentTypeDto>> TryCreate(AgentTypeDto model)
        {
            string message = "You have no permission";
            
            var result = OperationResult<AgentTypeDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";
            
            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }
    }
}