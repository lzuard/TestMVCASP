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
        private readonly ProductUtilService _productUtilService;

        public UtilizationService(UtilizationRepository recordRepository,
            AgentService agentService,
            EmployeeService employeeService,
            TtnService ttnService,
            ProductUtilService productUtilService) : base(recordRepository)
        {
            _agentService = agentService;
            _employeeService = employeeService;
            _ttnService = ttnService;
            _productUtilService = productUtilService;
        }

        public async Task<OperationResult<UtilizationDto>> TryCreate(UtilizationApiDto apiModel)
        {
            OperationResult<UtilizationDto> getModelResult = await GetModelByModelApi(apiModel);

            if (!getModelResult.IsSuccess)
            {
                return getModelResult;
            }
            
            OperationResult<UtilizationDto> createResult = await Repository.Create(getModelResult.Result);
            
            if (!createResult.IsSuccess)
            {
                return createResult;
            }

            var createUtilProductsResult =
               await _productUtilService.TryCreateUtilProductsByUtilization(createResult.Result, apiModel.UtilProducts);
            
            if (!createUtilProductsResult.IsSuccess)
            {
                return OperationResult<UtilizationDto>.GetUnsuccessfulResult(createUtilProductsResult.Error.Message);
            }

            return createResult;
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