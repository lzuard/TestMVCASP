using System.Threading.Tasks;
using Contracts.Contracts.Supply;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class SupplyService : ServiceBase<SupplyRepository, SupplyDto>
    {
        private readonly AgentService _agentService;
        private readonly EmployeeService _employeeService;
        private readonly TtnService _ttnService;

        public SupplyService(SupplyRepository recordRepository,
            AgentService agentService,
            EmployeeService employeeService,
            TtnService ttnService)
            : base(recordRepository)
        {
            _agentService = agentService;
            _employeeService = employeeService;
            _ttnService = ttnService;
        }

        public async Task<OperationResult<SupplyDto>> TryCreate(SupplyApiDto apiModel)
        {
            OperationResult<SupplyDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Create(result.Result);
            }

            return result;
        }

        public async Task<OperationResult<SupplyDto>> TryUpdate(SupplyApiDto apiModel)
        {
            OperationResult<SupplyDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Update(result.Result);
            }

            return result;
        }

        public override Task<OperationResult<SupplyDto>> TryCreate(SupplyDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<SupplyDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<SupplyDto>> TryUpdate(SupplyDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<SupplyDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";

            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        private async Task<OperationResult<SupplyDto>> GetModelByModelApi(SupplyApiDto apiModel)
        {
            var supplierResult = await _agentService.TryGet(apiModel.SupplierId);
            var employeeResult = await _employeeService.TryGet(apiModel.EmployeeId);
            var transportCompanyResult = await _agentService.TryGet(apiModel.TransportCompanyId);
            var ttnResult = await _ttnService.TryGet(apiModel.TtnId);

            if (!supplierResult.IsSuccess)
            {
                return OperationResult<SupplyDto>.GetUnsuccessfulResult(supplierResult.Error.Message);
            }

            if (!employeeResult.IsSuccess)
            {
                return OperationResult<SupplyDto>.GetUnsuccessfulResult(employeeResult.Error.Message);
            }

            if (!transportCompanyResult.IsSuccess)
            {
                return OperationResult<SupplyDto>.GetUnsuccessfulResult(transportCompanyResult.Error.Message);
            }

            if (!ttnResult.IsSuccess)
            {
                return OperationResult<SupplyDto>.GetUnsuccessfulResult(ttnResult.Error.Message);
            }

            var model = new SupplyDto
            {
                Supplier = supplierResult.Result,
                Employee = employeeResult.Result,
                TransportCompany = transportCompanyResult.Result,
                Ttn = ttnResult.Result,
                PaymentDocument = apiModel.PaymentDocument,
                SupplyDate = apiModel.SupplyDate,
                IsAccepted = apiModel.IsAccepted,
                Extra = apiModel.Extra
            };


            return OperationResult<SupplyDto>.GetSuccessResult(model);
        }
    }
}