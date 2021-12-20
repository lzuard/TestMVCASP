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
    public class OrderRepository : RepositoryBase<OrderDto>
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<OperationResult<IEnumerable<OrderDto>>> GetByFilter(
            OrderFilterDto filterDto)
        {
            IEnumerable<OrderDto> result = await Context.Orders
                .Where(x =>
                    (x.Id == filterDto.OrderId || filterDto.OrderId == null) &&
                    (x.Client.Id == filterDto.ClientId || filterDto.ClientId == null) &&
                    (x.Employee.Id == filterDto.EmployeeId || filterDto.EmployeeId == null) &&
                    (x.TransportCompany.Id == filterDto.TransportCompanyId || filterDto.TransportCompanyId == null) &&
                    (x.Ttn.Id == filterDto.TtnId || filterDto.TtnId == null) &&
                    (x.PaymentDocument == filterDto.PaymentDocument || filterDto.PaymentDocument == null) &&
                    (x.OrderingDate == filterDto.OrderingDate || filterDto.OrderingDate == null) &&
                    (x.ShipmentDate == filterDto.ShipmentDate || filterDto.ShipmentDate == null) &&
                    (x.DeliveryDate == filterDto.DeliveryDate || filterDto.DeliveryDate == null) &&
                    (x.Status == filterDto.Status || filterDto.Status == null) &&
                    (x.IsAcceptTransportCompany == filterDto.IsAcceptTransportCompany ||
                     filterDto.IsAcceptTransportCompany == null) &&
                    (x.IsAcceptClient == filterDto.IsAcceptClient || filterDto.IsAcceptClient == null) &&
                    (x.Extra == filterDto.Extra || filterDto.Extra == null))
                .ToListAsync();

            return new OperationResult<IEnumerable<OrderDto>>(result);
        }
    }
}