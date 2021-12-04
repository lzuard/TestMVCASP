using Contracts.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Data.LTS.Database
{
    public partial class ApplicationContext
    {
        public DbSet<AddressDto> Addresses { get; set; }

        public DbSet<ClientDto> Clients { get; set; }

        public DbSet<EmployeeDto> Employees { get; set; }

        public DbSet<OrderDto> Orders { get; set; }

        public DbSet<ProductDto> Products { get; set; }

        public DbSet<ProductOrderDto> ProductOrders { get; set; }

        public DbSet<ProductSupplyDto> ProductSupplies { get; set; }

        public DbSet<ProductUtilDto> ProductUtils { get; set; }

        public DbSet<ReturnDto> Returns { get; set; }

        public DbSet<SupplierDto> Suppliers { get; set; }

        public DbSet<SupplyDto> Supplies { get; set; }

        public DbSet<TcDto> Tcs { get; set; }

        public DbSet<TtnDto> Ttns { get; set; }

        public DbSet<UtilizationDto> Utilizations { get; set; }

        public DbSet<UtilizerDto> Utilizers { get; set; }
    }
}