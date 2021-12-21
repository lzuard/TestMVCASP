using System.Collections.Generic;

namespace Services.Infrastructure.Services.Reports
{
    public class CostOrderAndProductListResultDto
    {
        public decimal TotalCost { get; set; }
        
        public List<CostOrderAndProductListListItemDto> Items { get; set; } = new();
    }
}