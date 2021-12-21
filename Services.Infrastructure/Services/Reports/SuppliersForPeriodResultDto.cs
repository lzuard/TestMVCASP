using System.Collections.Generic;

namespace Services.Infrastructure.Services.Reports
{
    public class SuppliersForPeriodResultDto
    {
        public List<SuppliersForPeriodListItemDto> Items { get; set; } = new();
    }
}