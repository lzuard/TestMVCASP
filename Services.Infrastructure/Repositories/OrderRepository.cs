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

        public override async Task<OperationResult<IEnumerable<OrderDto>>> GetAll()
        {
            IEnumerable<OrderDto> result = await Context.Orders
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .Include(x => x.Address)
                .Include(x => x.TransportCompany)
                .Include(x => x.Ttn)
                .ToListAsync();

            return OperationResult<IEnumerable<OrderDto>>.GetSuccessResult(result);
        }

        public override async Task<OperationResult<OrderDto>> Get(int modelId)
        {
            OrderDto model = await Context.Orders
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .Include(x => x.Address)
                .Include(x => x.TransportCompany)
                .Include(x => x.Ttn)
                .FirstOrDefaultAsync(x => x.Id == modelId);

            if (model == null)
            {
                string error = $"{typeof(OrderDto)} with id {modelId} not found";

                return OperationResult<OrderDto>.GetUnsuccessfulResult(error);
            }

            return OperationResult<OrderDto>.GetSuccessResult(model);
        }

        public async Task<OperationResult<IEnumerable<OrderDto>>> GetByFilter(
            OrderFilterDto filterDto)
        {
            IEnumerable<OrderDto> result = await Context.Orders
                .Include(x => x.Client)
                .Include(x => x.Employee)
                .Include(x => x.Address)
                .Include(x => x.TransportCompany)
                .Include(x => x.Ttn)
                .Where(x =>
                    (x.Id == filterDto.OrderId || filterDto.OrderId == null) &&
                    (x.Client.Id == filterDto.ClientId || filterDto.ClientId == null) &&
                    (x.Employee.Id == filterDto.EmployeeId || filterDto.EmployeeId == null) &&
                    (x.Address.Id == filterDto.AddressId || filterDto.AddressId == null) &&
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