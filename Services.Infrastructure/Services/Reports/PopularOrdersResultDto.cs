using System.Collections.Generic;

namespace Services.Infrastructure.Services.Reports
{
    public class PopularOrdersResultDto
    {
        public List<PopularOrdersListItemDto> Items { get; set; } = new();
    }
}