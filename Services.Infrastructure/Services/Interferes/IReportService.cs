using System.Threading.Tasks;
using Services.Infrastructure.Services.Reports;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services.Interferes
{
    public interface IReportService
    {
        Task<OperationResult<CostOrderAndProductListResultDto>> GetCostOrderAndProductList(
            CostOrderAndProductListApiParametersDto parameters);

        Task<OperationResult<SuppliersAndQuantityProductSupplierResultDto>> GetSuppliersAndQuantityProductSupplier
            (SuppliersAndQuantityProductSupplierApiParametersDto parameters);

        Task<OperationResult<ClientOrderListResultDto>> GetClientOrderList(ClientOrderListApiParametersDto parameters);

        Task<OperationResult<PopularOrdersResultDto>> GetPopularOrders();
    }
}