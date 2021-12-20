using System.Threading.Tasks;
using Contracts.Contracts.Return;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class ReturnService : ServiceBase<ReturnRepository, ReturnDto>
    {
        private readonly OrderService _orderService;
        private readonly EmployeeService _employeeService;
        private readonly TtnService _ttnService;

        public ReturnService(ReturnRepository recordRepository,
            OrderService orderService,
            EmployeeService employeeService,
            TtnService ttnService)
            : base(recordRepository)
        {
            _orderService = orderService;
            _employeeService = employeeService;
            _ttnService = ttnService;
        }

        public async Task<OperationResult<ReturnDto>> TryCreate(ReturnApiDto apiModel)
        {
            OperationResult<ReturnDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Create(result.Result);
            }

            return result;
        }

        public async Task<OperationResult<ReturnDto>> TryUpdate(ReturnApiDto apiModel)
        {
            OperationResult<ReturnDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Update(result.Result);
            }

            return result;
        }

        public override Task<OperationResult<ReturnDto>> TryCreate(ReturnDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<ReturnDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<ReturnDto>> TryUpdate(ReturnDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<ReturnDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";

            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        private async Task<OperationResult<ReturnDto>> GetModelByModelApi(ReturnApiDto apiModel)
        {
            var orderResult = await _orderService.TryGet(apiModel.OrderId);
            var employeeResult = await _employeeService.TryGet(apiModel.EmployeeId);
            var ttnResult = await _ttnService.TryGet(apiModel.TtnId);

            if (!orderResult.IsSuccess)
            {
                return OperationResult<ReturnDto>.GetUnsuccessfulResult(orderResult.Error.Message);
            }

            if (!employeeResult.IsSuccess)
            {
                return OperationResult<ReturnDto>.GetUnsuccessfulResult(employeeResult.Error.Message);
            }

            if (!ttnResult.IsSuccess)
            {
                return OperationResult<ReturnDto>.GetUnsuccessfulResult(ttnResult.Error.Message);
            }

            var model = new ReturnDto
            {
                Order = orderResult.Result,
                Ttn = ttnResult.Result,
                Employee = employeeResult.Result,
                ReturnDate = apiModel.ReturnDate,
                ReturnAct = apiModel.ReturnAct,
                IsAccepted = apiModel.IsAccepted
            };

            return OperationResult<ReturnDto>.GetSuccessResult(model);
        }
    }
}