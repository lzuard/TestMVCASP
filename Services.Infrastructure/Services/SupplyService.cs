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
        private readonly ProductSupplyService _productSupplyService;

        public SupplyService(SupplyRepository recordRepository,
            AgentService agentService,
            EmployeeService employeeService,
            TtnService ttnService,
            ProductSupplyService productSupplyService)
            : base(recordRepository)
        {
            _agentService = agentService;
            _employeeService = employeeService;
            _ttnService = ttnService;
            _productSupplyService = productSupplyService;
        }

        public async Task<OperationResult<SupplyDto>> TryCreate(SupplyApiDto apiModel)
        {
            OperationResult<SupplyDto> convertResult = await GetModelByModelApi(apiModel);

            if (!convertResult.IsSuccess)
            {
                return convertResult;
            }

            OperationResult<SupplyDto> createSupplyResult = await Repository.Create(convertResult.Result);

            if (!createSupplyResult.IsSuccess)
            {
                return createSupplyResult;
            }

            SupplyDto supply = createSupplyResult.Result;

            var createSupplyProductsResult =
                await _productSupplyService.CreateSupplyProductsByOrder(supply, apiModel.SupplyProducts);

            if (!createSupplyProductsResult.IsSuccess)
            {
                await Repository.Delete(supply.Id);

                return OperationResult<SupplyDto>.GetUnsuccessfulResult(createSupplyProductsResult.Error.Message);
            }

            return createSupplyResult;
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