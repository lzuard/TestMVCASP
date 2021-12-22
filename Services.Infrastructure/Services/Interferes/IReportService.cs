using System.Threading.Tasks;
using Services.Infrastructure.Services.Reports;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services.Interferes
{
    public interface IReportService
    {
        Task<OperationResult<CostOrderAndProductListResultDto>> TryGetCostOrderAndProductList(
            CostOrderAndProductListApiParametersDto parameters);

        Task<OperationResult<SuppliersForPeriodResultDto>> TryGetSuppliersForPeriod
            (SuppliersForPeriodApiParametersDto parameters);

        Task<OperationResult<ClientOrderListResultDto>> TryGetClientOrderList(ClientOrderListApiParametersDto parameters);

        Task<OperationResult<PopularOrdersResultDto>> TryGetPopularOrders();
    }
}