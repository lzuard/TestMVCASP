using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Contracts.Records;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;
using Services.Infrastructure.SearchParameters;

namespace Services.Infrastructure.Repositories
{
    public class OrderRepository : RecordRepositoryBase<OrderRecordDto>
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<OperationResult<IEnumerable<OrderRecordDto>>> GetOrderByFilter(
            OrderSearchParameters searchParameters)
        {
            IEnumerable<OrderRecordDto> result = await Context.Orders
                .Where(x =>
                    Helpers.NullableEquals(x.Id, searchParameters.OrderId) &&
                    Helpers.NullableEquals(x.ClientId, searchParameters.ClientId) &&
                    Helpers.NullableEquals(x.EmployeeId, searchParameters.EmployeeId) &&
                    Helpers.NullableEquals(x.TransportCompanyId, searchParameters.TransportCompanyId) &&
                    Helpers.NullableEquals(x.TtnId, searchParameters.TtnId) &&
                    Helpers.NullableEquals(x.PaymentDocument, searchParameters.PaymentDocument) &&
                    Helpers.NullableEquals(x.OrderingDate, searchParameters.OrderingDate) &&
                    Helpers.NullableEquals(x.ShipmentDate, searchParameters.ShipmentDate) &&
                    Helpers.NullableEquals(x.DeliveryDate, searchParameters.DeliveryDate) &&
                    Helpers.NullableEquals(x.Status, searchParameters.Status) &&
                    Helpers.NullableEquals(x.IsAcceptTransportCompany, searchParameters.IsAcceptTransportCompany) &&
                    Helpers.NullableEquals(x.IsAcceptClient, searchParameters.IsAcceptClient) &&
                    Helpers.NullableEquals(x.Extra, searchParameters.Extra))
                .ToListAsync();

            return new OperationResult<IEnumerable<OrderRecordDto>>(result);
        }
    }
}