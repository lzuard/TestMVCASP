using System.Collections.Generic;

namespace Services.Infrastructure.Services.Reports
{
    public class ClientOrderListResultDto
    {
        public decimal TotalPrice { get; set; }
        
        public List<ClientOrderListListItemDto> Items { get; set; } = new();
    }
}