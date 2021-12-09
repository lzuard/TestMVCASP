using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Records;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.SearchParameters;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class OrderRecordService : RecordServiceBase<OrderRepository, OrderRecordDto>
    {
        public OrderRecordService(OrderRepository recordRepository) : base(recordRepository)
        {
        }

        public async Task<OperationResult<IEnumerable<OrderRecordDto>>> TryGetOrderByFilter(
            OrderSearchParameters searchParameters)
        {
            return await Repository.GetOrderByFilter(searchParameters);
        }
    }
}