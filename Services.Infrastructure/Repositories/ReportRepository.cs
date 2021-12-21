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

        public async Task<OperationResult<IEnumerable<PopularOrdersListItemDto>>> GetPopularOrdersListItems()
        {
            try
            {
                
                IEnumerable<PopularOrdersListItemDto> result = await _context.ProductOrders
                    .Include(x=>x.Order)
                    .Include(x=>x.Product)
                    .GroupBy(x => x.Product.Id)
                    .Select(x => new PopularOrdersListItemDto()
                    {
                        ProductName = x.First().Product.Name,
                        Count = x.Sum(s => s.Quantity)
                    })
                    .OrderByDescending(x => x.Count)
                    .Take(3)
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