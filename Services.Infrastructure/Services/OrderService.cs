using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Contracts.Order;
using Services.Infrastructure.Repositories;
using Services.Infrastructure.Services.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Services
{
    public class OrderService : ServiceBase<OrderRepository, OrderDto>
    {
        public OrderService(OrderRepository recordRepository) : base(recordRepository)
        {
        }

        public override async Task<OperationResult<IEnumerable<OrderDto>>> TryGetAll()
        {
            return await Repository.GetAll();
        }

        public async Task<OperationResult<IEnumerable<OrderDto>>> TryGetOrderByFilter(
            OrderFilterDto filterDto)
        {
            return await Repository.GetByFilter(filterDto);
        }
    }
}