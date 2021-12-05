using Contracts.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Data.LTS.Database
{
    public partial class ApplicationContext
    {
        public DbSet<AddressDto> Addresses { get; set; } = null!;

        public DbSet<ClientDto> Clients { get; set; } = null!;

        public DbSet<EmployeeDto> Employees { get; set; } = null!;

        public DbSet<OrderDto> Orders { get; set; } = null!;

        public DbSet<ProductDto> Products { get; set; } = null!;

        public DbSet<ProductOrderDto> ProductOrders { get; set; } = null!;

        public DbSet<ProductSupplyDto> ProductSupplies { get; set; } = null!;

        public DbSet<ProductUtilDto> ProductUtils { get; set; } = null!;

        public DbSet<ReturnDto> Returns { get; set; } = null!;

        public DbSet<SupplierDto> Suppliers { get; set; } = null!;

        public DbSet<SupplyDto> Supplies { get; set; } = null!;

        public DbSet<TcDto> Tcs { get; set; } = null!;

        public DbSet<TtnDto> Ttns { get; set; } = null!;

        public DbSet<UtilizationDto> Utilizations { get; set; } = null!;

        public DbSet<UtilizerDto> Utilizers { get; set; } = null!;
    }
}