using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Contracts.Records;
using Contracts.Contracts.StaticObjects;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Repositories.Base;
using Services.Infrastructure.Utils;
using Services.Infrastructure.SearchParameters;

namespace Services.Infrastructure.Repositories
{
    public class OrderRepository : RecordRepositoryBase<OrderRecordDto>
    {
        private readonly List<OrderRecordDto> _orders = new()
        {
            new OrderRecordDto()
            {
                Id = 1,
                AddressId = 1,
                ClientId = 1,
                EmployeeId = 1,
                TransportCompanyId = 1,
                TtnId = 1,
                PaymentDocument = "67430000023021",
                OrderingDate  = new DateTime(2021,12,10),
                ShipmentDate= new DateTime(2021,12,12),
                DeliveryDate = new DateTime(2021,12,17),
                Status = OrderStatus.Accepted,
                IsAcceptTransportCompany = true,
                IsAcceptClient = false,
                Extra = "Хрупкое"
            },
            new OrderRecordDto()
            {
                Id = 2,
                AddressId = 2,
                ClientId = 2,
                EmployeeId = 1,
                TransportCompanyId = 1,
                TtnId = 2,
                PaymentDocument = "67343200023021",
                OrderingDate  = new DateTime(2021,12,12),
                ShipmentDate= new DateTime(2021,12,16),
                DeliveryDate = new DateTime(2021,12,17),
                Status = OrderStatus.Completed,
                IsAcceptTransportCompany = true,
                IsAcceptClient = true,
            },
            new OrderRecordDto()
            {
                Id = 1,
                AddressId = 1,
                ClientId = 1,
                EmployeeId = 1,
                TransportCompanyId = 1,
                TtnId = 1,
                PaymentDocument = "67430000023021",
                OrderingDate  = new DateTime(2021,12,14),
                ShipmentDate= new DateTime(2021,12,15),
                DeliveryDate = new DateTime(2021,12,20),
                Status = OrderStatus.Refund,
                IsAcceptTransportCompany = false,
                IsAcceptClient = false,
            },
        };
        
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public override Task<OperationResult<List<OrderRecordDto>>> GetAll()
        {
            return Task.FromResult(new OperationResult<List<OrderRecordDto>>(_orders));
        }
        
        public override Task<OperationResult<OrderRecordDto>> Get(int modelId)
        {
            OrderRecordDto order = _orders.FirstOrDefault(x => x.Id == modelId);

            if (order == null)
            {
                string error = $"Model with {modelId} not found";

                return Task.FromResult(
                    new OperationResult<OrderRecordDto>(
                        new OperationResult<OrderRecordDto>.OperationResultError(error)));
            }
            
            return Task.FromResult(new OperationResult<OrderRecordDto>(order));
        }

        public Task<OperationResult<IEnumerable<OrderRecordDto>>> GetOrderByFilter(
            OrderSearchParameters searchParameters)
        {
            IEnumerable<OrderRecordDto> result = _orders.Where(x =>
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
                .ToList();
            /*
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
                */

            return Task.FromResult(new OperationResult<IEnumerable<OrderRecordDto>>(result));
        }
    }
}