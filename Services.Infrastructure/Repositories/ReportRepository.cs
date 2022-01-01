using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.LTS.Database;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.Services.Reports;
using Services.Infrastructure.Utils;

namespace Services.Infrastructure.Repositories
{
    public class ReportRepository
    {
        private readonly ApplicationContext _context;

        public ReportRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<OperationResult<IEnumerable<CostOrderAndProductListListItemDto>>>
            GetCostOrderAndProductListListItems(int orderId)
        {
            try
            {
                var result = await _context.ProductOrders
                    .Include(x => x.Order)
                    .Include(x => x.Product)
                    .Include(x => x.Product.Category.ParentCategory)
                    .Where(x => x.Order.Id == orderId)
                    .GroupBy(x => x.Product.Id)
                    .Select(x => new CostOrderAndProductListListItemDto
                    {
                        ProductArt = x.First().Product.Art,
                        Manufacture = x.First().Product.Manufacture,
                        Name = x.First().Product.Name,
                        PackageType = x.First().Product.PackageType,
                        Category = x.First().Product.Category,
                        Quantity = x.Sum(z => z.Quantity),
                        Price = x.First().Product.Price
                    }).ToListAsync();

                return OperationResult<IEnumerable<CostOrderAndProductListListItemDto>>.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<CostOrderAndProductListListItemDto>>.GetUnsuccessfulResult(
                    ex.Message);
            }
        }

        public async Task<OperationResult<IEnumerable<SuppliersForPeriodListItemDto>>> GetSuppliersForPeriodListItems(
            DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _context.Supplies
                    .Include(x => x.Supplier)
                    .Where(x => x.SupplyDate >= startDate && x.SupplyDate <= endDate)
                    .GroupBy(x => x.Supplier.Id)
                    .Select(x => new SuppliersForPeriodListItemDto
                    {
                        SupplierName = x.First().Supplier.OrganizationName,
                        SupplyCount = x.Count()
                    })
                    .ToListAsync();
                

                return OperationResult<IEnumerable<SuppliersForPeriodListItemDto>>.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<SuppliersForPeriodListItemDto>>.GetUnsuccessfulResult(ex.Message);
            }
        }

        public async Task<OperationResult<IEnumerable<ClientOrderListListItemDto>>> GetClientOrderListListItems(
            int clientId)
        {
            try
            {
                var result = await _context.Orders
                    .Include(x => x.Employee)
                    .Include(x => x.Address)
                    .Include(x => x.TransportCompany)
                    .Where(x => x.Client.Id == clientId)
                    .Select(x => new ClientOrderListListItemDto
                    {
                        OrderId = x.Id,
                        EmployeeName = Helpers.GetEmployeeFormatName(x.Employee),
                        TransportCompanyName = x.TransportCompany.OrganizationName,
                        Address = $"{x.Address.Index}, {x.Address.Subject}, {x.Address.Location}",
                        PaymentDocument = x.PaymentDocument,
                        OrderingDate = x.OrderingDate,
                        ShipmentDate = x.ShipmentDate,
                        DeliveryDate = x.DeliveryDate,
                        Status = x.Status,
                        IsAcceptTransportCompany = x.IsAcceptTransportCompany,
                        IsAcceptClient = x.IsAcceptClient,
                        Extra = x.Extra
                    })
                    .ToListAsync();


                return OperationResult<IEnumerable<ClientOrderListListItemDto>>.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<ClientOrderListListItemDto>>.GetUnsuccessfulResult(ex.Message);
            }
        }

        public async Task<OperationResult<decimal>> GetClientTotalPrice(int clientId)
        {
            try
            {
                var result = await _context.ProductOrders
                    .Where(x => x.Order.Client.Id == clientId)
                    .SumAsync(x => x.Quantity * x.Product.Price);


                return OperationResult<decimal>.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<decimal>.GetUnsuccessfulResult(ex.Message);
            }
        }

        public async Task<OperationResult<IEnumerable<PopularOrdersListItemDto>>> GetPopularOrdersListItems()
        {
            try
            {
                IEnumerable<PopularOrdersListItemDto> result = await _context.ProductOrders
                    .Include(x => x.Order)
                    .Include(x => x.Product)
                    .GroupBy(x => x.Product.Id)
                    .Select(x => new PopularOrdersListItemDto()
                    {
                        ProductName = x.First().Product.Name,
                        Count = x.Sum(s => s.Quantity)
                    })
                    .OrderByDescending(x => x.Count)
                    .ToListAsync();

                return OperationResult<IEnumerable<PopularOrdersListItemDto>>.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<PopularOrdersListItemDto>>.GetUnsuccessfulResult(ex.Message);
            }
        }
    }
}