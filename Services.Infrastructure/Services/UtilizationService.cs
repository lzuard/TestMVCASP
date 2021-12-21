using System.Threading.Tasks;
using Contracts.Contracts.Utilization;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class UtilizationService : ServiceBase<UtilizationRepository, UtilizationDto>
    {
        private readonly AgentService _agentService;
        private readonly EmployeeService _employeeService;
        private readonly TtnService _ttnService;

        public UtilizationService(UtilizationRepository recordRepository,
            AgentService agentService,
            EmployeeService employeeService,
            TtnService ttnService) : base(recordRepository)
        {
            _agentService = agentService;
            _employeeService = employeeService;
            _ttnService = ttnService;
        }

        public async Task<OperationResult<UtilizationDto>> TryCreate(UtilizationApiDto apiModel)
        {
            OperationResult<UtilizationDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Create(result.Result);
            }

            return result;
        }

        public async Task<OperationResult<UtilizationDto>> TryUpdate(UtilizationApiDto apiModel)
        {
            OperationResult<UtilizationDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Update(result.Result);
            }

            return result;
        }

        public override Task<OperationResult<UtilizationDto>> TryCreate(UtilizationDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<UtilizationDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<UtilizationDto>> TryUpdate(UtilizationDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<UtilizationDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";

            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        private async Task<OperationResult<UtilizationDto>> GetModelByModelApi(UtilizationApiDto apiModel)
        {
            var utilizerResult = await _agentService.TryGet(apiModel.UtilizerId);
            var employeeResult = await _employeeService.TryGet(apiModel.EmployeeId);
            var ttnResult = await _ttnService.TryGet(apiModel.TtnId);

            if (!utilizerResult.IsSuccess)
            {
                return OperationResult<UtilizationDto>.GetUnsuccessfulResult(utilizerResult.Error.Message);
            }

            if (!employeeResult.IsSuccess)
            {
                return OperationResult<UtilizationDto>.GetUnsuccessfulResult(employeeResult.Error.Message);
            }

            if (!ttnResult.IsSuccess)
            {
                return OperationResult<UtilizationDto>.GetUnsuccessfulResult(ttnResult.Error.Message);
            }

            var model = new UtilizationDto
            {
                Employee = employeeResult.Result,
                Ttn = ttnResult.Result,
                Utilizer = utilizerResult.Result,
                UtilizationAct = apiModel.UtilizationAct,
                ShipmentDate = apiModel.ShipmentDate
            };

            return OperationResult<UtilizationDto>.GetSuccessResult(model);
        }
    }
}