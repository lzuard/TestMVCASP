using System.Collections.Generic;
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
        
        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        private readonly ProductOrderService _productOrderService;
        
        public ReportService(ReportRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<OperationResult<CostOrderAndProductListResultDto>> GetCostOrderAndProductList(
            CostOrderAndProductListApiParametersDto parameters)
        {
            throw new System.NotImplementedException();
        }

        public async Task<OperationResult<SuppliersAndQuantityProductSupplierResultDto>>
            GetSuppliersAndQuantityProductSupplier(SuppliersAndQuantityProductSupplierApiParametersDto parameters)
        {
            throw new System.NotImplementedException();
        }

        public async Task<OperationResult<ClientOrderListResultDto>> GetClientOrderList(
            ClientOrderListApiParametersDto parameters)
        {
            throw new System.NotImplementedException();
        }

        public async Task<OperationResult<PopularOrdersResultDto>> GetPopularOrders()
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