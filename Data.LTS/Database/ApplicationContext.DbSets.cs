using Contracts.Contracts.Address;
using Contracts.Contracts.Agent;
using Contracts.Contracts.AgentType;
using Contracts.Contracts.Employee;
using Contracts.Contracts.Order;
using Contracts.Contracts.Product;
using Contracts.Contracts.ProductOrder;
using Contracts.Contracts.ProductSupply;
using Contracts.Contracts.ProductUtil;
using Contracts.Contracts.Records;
using Contracts.Contracts.Supply;
using Contracts.Contracts.Ttn;
using Contracts.Contracts.Utilization;
using Microsoft.EntityFrameworkCore;

namespace Data.LTS.Database
{
    public partial class ApplicationContext
    {
        public DbSet<AgentRecordDto> Agents { get; set; } = null!;
        
        public DbSet<AgentTypeRecordDto> AgentTypes { get; set; } = null!;
        
        public DbSet<AddressRecordDto> Addresses { get; set; } = null!;

        public DbSet<EmployeeRecordDto> Employees { get; set; } = null!;
        public DbSet<OrderRecordDto> Orders { get; set; } = null!;

        public DbSet<ProductRecordDto> Products { get; set; } = null!;

        public DbSet<ProductOrderRecordDto> ProductOrders { get; set; } = null!;

        public DbSet<ProductSupplyRecordDto> ProductSupplies { get; set; } = null!;

        public DbSet<ProductUtilRecordDto> ProductUtils { get; set; } = null!;

        public DbSet<ReturnRecordDto> Returns { get; set; } = null!;

        public DbSet<SupplyRecordDto> Supplies { get; set; } = null!;

        public DbSet<TtnRecordDto> Ttns { get; set; } = null!;

        public DbSet<UtilizationRecordDto> Utilizations { get; set; } = null!;
    }
}