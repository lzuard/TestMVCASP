using System;

namespace Services.Infrastructure.Services.Reports
{
    public class SuppliersForPeriodApiParametersDto
    {
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}