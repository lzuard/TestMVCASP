using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Contracts.Order;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class OrderRepository : RecordRepositoryBase<OrderDto>
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<OperationResult<IEnumerable<OrderDto>>> GetOrderByFilter(
            OrderFilterParametersDto filterParametersDto)
        {
            throw new NotImplementedException();
            /*
            IEnumerable<OrderDto> result = await Context.Orders
                .Where(x =>
                    Helpers.NullableEquals(x.Id, filterParametersDto.OrderId) &&
                    Helpers.NullableEquals(x.ClientId, filterParametersDto.ClientId) &&
                    Helpers.NullableEquals(x.EmployeeId, filterParametersDto.EmployeeId) &&
                    Helpers.NullableEquals(x.TransportCompanyId, filterParametersDto.TransportCompanyId) &&
                    Helpers.NullableEquals(x.TtnId, filterParametersDto.TtnId) &&
                    Helpers.NullableEquals(x.PaymentDocument, filterParametersDto.PaymentDocument) &&
                    Helpers.NullableEquals(x.OrderingDate, filterParametersDto.OrderingDate) &&
                    Helpers.NullableEquals(x.ShipmentDate, filterParametersDto.ShipmentDate) &&
                    Helpers.NullableEquals(x.DeliveryDate, filterParametersDto.DeliveryDate) &&
                    Helpers.NullableEquals(x.Status, filterParametersDto.Status) &&
                    Helpers.NullableEquals(x.IsAcceptTransportCompany, filterParametersDto.IsAcceptTransportCompany) &&
                    Helpers.NullableEquals(x.IsAcceptClient, filterParametersDto.IsAcceptClient) &&
                    Helpers.NullableEquals(x.Extra, filterParametersDto.Extra))
                .ToListAsync();

            return new OperationResult<IEnumerable<OrderDto>>(result);
            */
        }
    }
}