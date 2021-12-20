using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Address;
using Contracts.Contracts.Agent;
using Contracts.Contracts.Employee;
using Contracts.Contracts.Order;
using Contracts.Contracts.Ttn;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class OrderService : ServiceBase<OrderRepository, OrderDto>
    {
        private readonly AgentService _agentService;
        private readonly EmployeeService _employeeService;
        private readonly AddressService _addressService;
        private readonly TtnService _ttnService;
        private readonly ProductOrderService _productOrderService;

        public OrderService(
            OrderRepository recordRepository,
            AgentService agentService,
            EmployeeService employeeService,
            AddressService addressService,
            TtnService ttnService,
            ProductOrderService productOrderService)
            : base(recordRepository)
        {
            _agentService = agentService;
            _employeeService = employeeService;
            _addressService = addressService;
            _ttnService = ttnService;
            _productOrderService = productOrderService;
        }

        public async Task<OperationResult<OrderDto>> TryCreate(OrderApiDto apiModel)
        {
            OperationResult<OrderDto> result = await GetModelByModelApi(apiModel);

            if (!result.IsSuccess)
            {
                return result;
            }
            
            var createOrderResult = await Repository.Create(result.Result);

            if (!createOrderResult.IsSuccess)
            {
                OperationResult<OrderDto>.GetUnsuccessfulResult(createOrderResult.Error.Message);
            }

            OrderDto order = createOrderResult.Result;

            var productOrdersResult =
                await _productOrderService.CreateProductOrderByOrder(result.Result, apiModel.OrderProducts);
            
            if (!productOrdersResult.IsSuccess)
            {
                var deleteResult = await Repository.Delete(order.Id);

                if (!deleteResult.IsSuccess)
                {
                    string message = $"Fail in transaction. Please delete order with id {order}. ";

                    return OperationResult<OrderDto>.GetUnsuccessfulResult(message + deleteResult.Error.Message);
                }
                
                return OperationResult<OrderDto>.GetUnsuccessfulResult(productOrdersResult.Error.Message);
            }

            return createOrderResult;
        }

        public async Task<OperationResult<OrderDto>> TryUpdate(OrderApiDto apiModel)
        {
            OperationResult<OrderDto> result = await GetModelByModelApi(apiModel);

            if (result.IsSuccess)
            {
                return await Repository.Update(result.Result);
            }

            return result;
        }

        public override Task<OperationResult<OrderDto>> TryCreate(OrderDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<OrderDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<OrderDto>> TryUpdate(OrderDto model)
        {
            string message = "You have no permission";

            var result = OperationResult<OrderDto>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public override Task<OperationResult<bool>> TryDelete(int modelId)
        {
            string message = "You have no permission";

            var result = OperationResult<bool>.GetUnsuccessfulResult(message);

            return Task.FromResult(result);
        }

        public async Task<OperationResult<IEnumerable<OrderDto>>> TryGetOrderByFilter(
            OrderFilterDto filterDto)
        {
            return await Repository.GetByFilter(filterDto);
        }

        private async Task<OperationResult<OrderDto>> GetModelByModelApi(OrderApiDto apiModel)
        {
            OperationResult<AgentDto> clientResult = await _agentService.TryGet(apiModel.ClientId);
            OperationResult<EmployeeDto> employeeResult = await _employeeService.TryGet(apiModel.EmployeeId);
            OperationResult<AgentDto> transportCompanyResult = await _agentService.TryGet(apiModel.TransportCompanyId);
            OperationResult<AddressDto> addressResult = await _addressService.TryGet(apiModel.AddressId);
            OperationResult<TtnDto> ttnResult = await _ttnService.TryGet(apiModel.TtnId);

            if (!clientResult.IsSuccess)
            {
                return OperationResult<OrderDto>.GetUnsuccessfulResult(clientResult.Error.Message);
            }

            if (!employeeResult.IsSuccess)
            {
                return OperationResult<OrderDto>.GetUnsuccessfulResult(employeeResult.Error.Message);
            }

            if (!transportCompanyResult.IsSuccess)
            {
                return OperationResult<OrderDto>.GetUnsuccessfulResult(clientResult.Error.Message);
            }

            if (!addressResult.IsSuccess)
            {
                return OperationResult<OrderDto>.GetUnsuccessfulResult(addressResult.Error.Message);
            }

            if (!ttnResult.IsSuccess)
            {
                return OperationResult<OrderDto>.GetUnsuccessfulResult(ttnResult.Error.Message);
            }

            var model = new OrderDto
            {
                Client = clientResult.Result,
                Employee = employeeResult.Result,
                TransportCompany = transportCompanyResult.Result,
                Address = addressResult.Result,
                Ttn = ttnResult.Result,
                PaymentDocument = apiModel.PaymentDocument,
                OrderingDate = apiModel.OrderingDate,
                ShipmentDate = apiModel.ShipmentDate,
                DeliveryDate = apiModel.DeliveryDate,
                Status = apiModel.Status,
                IsAcceptTransportCompany = apiModel.IsAcceptTransportCompany,
                IsAcceptClient = apiModel.IsAcceptClient,
                Extra = apiModel.Extra
            };

            return OperationResult<OrderDto>.GetSuccessResult(model);
        }
    }
}