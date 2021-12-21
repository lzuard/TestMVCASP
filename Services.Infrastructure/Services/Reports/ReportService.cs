using System.Linq;
using System.Threading.Tasks;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Interferes;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly ReportRepository _repository;
        private readonly AgentService _agentService;

        public ReportService(ReportRepository repository, AgentService agentService)
        {
            _repository = repository;
            _agentService = agentService;
        }

        public async Task<OperationResult<CostOrderAndProductListResultDto>> TryGetCostOrderAndProductList(
            CostOrderAndProductListApiParametersDto parameters)
        {
            var getItemsResult = await _repository.GetCostOrderAndProductListListItems(parameters.OrderId);

            if (!getItemsResult.IsSuccess)
            {
                return OperationResult<CostOrderAndProductListResultDto>.GetUnsuccessfulResult(getItemsResult.Error
                    .Message);
            }

            var result = new CostOrderAndProductListResultDto
            {
                TotalCost = getItemsResult.Result.Sum(x => x.Price * x.Quantity),
                Items = getItemsResult.Result.ToList()
            };

            return OperationResult<CostOrderAndProductListResultDto>.GetSuccessResult(result);
        }

        public async Task<OperationResult<SuppliersForPeriodResultDto>> TryGetSuppliersForPeriod(
            SuppliersForPeriodApiParametersDto parameters)
        {
            var getListItemsResult =
                await _repository.GetSuppliersForPeriodListItems(parameters.StartDate, parameters.EndDate);

            if (!getListItemsResult.IsSuccess)
            {
                return OperationResult<SuppliersForPeriodResultDto>.GetUnsuccessfulResult(getListItemsResult.Error
                    .Message);
            }

            var result = new SuppliersForPeriodResultDto
            {
                Items = getListItemsResult.Result.ToList()
            };

            return OperationResult<SuppliersForPeriodResultDto>.GetSuccessResult(result);
        }

        public async Task<OperationResult<ClientOrderListResultDto>> TryGetClientOrderList(
            ClientOrderListApiParametersDto parameters)
        {
            var result = new ClientOrderListResultDto();

            var getClientResult = await _agentService.TryGet(parameters.ClientId);

            if (!getClientResult.IsSuccess || getClientResult.Result.Type.Name != "Клиент")
            {
                return OperationResult<ClientOrderListResultDto>.GetSuccessResult(result);
            }

            var getItemResult = await _repository.GetClientOrderListListItems(parameters.ClientId);
            var getTotalPriceResult = await _repository.GetClientTotalPrice(parameters.ClientId);

            if (!getItemResult.IsSuccess)
            {
                return OperationResult<ClientOrderListResultDto>.GetUnsuccessfulResult(getItemResult.Error.Message);
            }

            if (!getTotalPriceResult.IsSuccess)
            {
                return OperationResult<ClientOrderListResultDto>.GetUnsuccessfulResult(
                    getTotalPriceResult.Error.Message);
            }

            result.Items = getItemResult.Result.ToList();
            result.TotalPrice = getTotalPriceResult.Result;

            return OperationResult<ClientOrderListResultDto>.GetSuccessResult(result);
        }

        public async Task<OperationResult<PopularOrdersResultDto>> TryGetPopularOrders()
        {
            var itemsResult = await _repository.GetPopularOrdersListItems();

            if (!itemsResult.IsSuccess)
            {
                OperationResult<PopularOrdersResultDto>.GetUnsuccessfulResult(itemsResult.Error.Message);
            }

            var result = new PopularOrdersResultDto
            {
                Items = itemsResult.Result.ToList()
            };

            return OperationResult<PopularOrdersResultDto>.GetSuccessResult(result);
        }
    }
}