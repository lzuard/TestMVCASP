using Contracts.Contracts.Address;
using Contracts.Contracts.Agent;
using Contracts.Contracts.AgentType;
using Contracts.Contracts.Category;
using Contracts.Contracts.Employee;
using Contracts.Contracts.Order;
using Contracts.Contracts.Product;
using Contracts.Contracts.ProductOrder;
using Contracts.Contracts.ProductSupply;
using Contracts.Contracts.ProductUtil;
using Contracts.Contracts.Return;
using Contracts.Contracts.Supply;
using Contracts.Contracts.Ttn;
using Contracts.Contracts.Utilization;
using Microsoft.EntityFrameworkCore;

namespace Data.LTS.Database
{
    public partial class ApplicationContext
    {
        public DbSet<AgentDto> Agents { get; set; } = null!;
        
        public DbSet<AgentTypeDto> AgentTypes { get; set; } = null!;
        
        public DbSet<AddressDto> Addresses { get; set; } = null!;

        public DbSet<EmployeeDto> Employees { get; set; } = null!;
        
        public DbSet<CategoryDto> Categories { get; set; } = null!;
        
        public DbSet<OrderDto> Orders { get; set; } = null!;

        public DbSet<ProductDto> Products { get; set; } = null!;

        public DbSet<ProductOrderDto> ProductOrders { get; set; } = null!;

        public DbSet<ProductSupplyDto> ProductSupplies { get; set; } = null!;

        public DbSet<ProductUtilDto> ProductUtils { get; set; } = null!;

        public DbSet<ReturnDto> Returns { get; set; } = null!;

        public DbSet<SupplyDto> Supplies { get; set; } = null!;

        public DbSet<TtnDto> Ttns { get; set; } = null!;

        public DbSet<UtilizationDto> Utilizations { get; set; } = null!;
    }
}