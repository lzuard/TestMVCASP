using System.Threading.Tasks;
using Contracts.Contracts.Address;
using Contracts.Contracts.Agent;
using Contracts.Contracts.AgentType;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class AgentService : ServiceBase<AgentRepository, AgentDto>
    {
        private readonly AddressService _addressService;
        private readonly AgentTypeService _agentTypeService;

        public AgentService(AgentRepository recordRepository, AddressService addressService,
            AgentTypeService agentTypeService) : base(recordRepository)
        {
            _addressService = addressService;
            _agentTypeService = agentTypeService;
        }

        public async Task<OperationResult<AgentDto>> TryCreate(AgentApiDto apiModel)
        {
            OperationResult<AgentDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Create(result.Result);
            }

            return result;
        }

        public async Task<OperationResult<AgentDto>> TryUpdate(AgentApiDto apiModel)
        {
            OperationResult<AgentDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Update(result.Result);
            }

            return result;
        }

        public override Task<OperationResult<AgentDto>> TryCreate(AgentDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<AgentDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<AgentDto>> TryUpdate(AgentDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<AgentDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";

            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        private async Task<OperationResult<AgentDto>> GetModelByModelApi(AgentApiDto apiModel)
        {
            AddressDto address;
            AgentTypeDto agentType;

            var addressResult = await _addressService.TryGet(apiModel.AddressId);

            if (addressResult.IsSuccess)
            {
                address = addressResult.Result;
            }
            else
            {
                return OperationResult<AgentDto>.GetUnsuccessfulResult(addressResult.Error.Message);
            }

            var agentTypeResult = await _agentTypeService.TryGet(apiModel.AgentTypeId);

            if (addressResult.IsSuccess)
            {
                agentType = agentTypeResult.Result;
            }
            else
            {
                return OperationResult<AgentDto>.GetUnsuccessfulResult(addressResult.Error.Message);
            }

            var agent = new AgentDto
            {
                Type = agentType,
                Address = address,
                OrganizationName = apiModel.OrganizationName,
                CheckingAccount = apiModel.CheckingAccount,
                IndividualTaxpayerNumber = apiModel.IndividualTaxpayerNumber,
                Phone = apiModel.Phone,
                Email = apiModel.Email
            };

            return OperationResult<AgentDto>.GetSuccessResult(agent);
        }
    }
}