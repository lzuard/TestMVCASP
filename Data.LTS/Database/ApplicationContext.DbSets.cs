using Contracts.Contracts.Records;
using Microsoft.EntityFrameworkCore;

namespace Data.LTS.Database
{
    public partial class ApplicationContext
    {
        public DbSet<AddressRecordDto> Addresses { get; set; } = null!;

        public DbSet<ClientRecordDto> Clients { get; set; } = null!;

        public DbSet<EmployeeRecordDto> Employees { get; set; } = null!;

        public DbSet<OrderRecordDto> Orders { get; set; } = null!;

        public DbSet<ProductRecordDto> Products { get; set; } = null!;

        public DbSet<ProductOrderRecordDto> ProductOrders { get; set; } = null!;

        public DbSet<ProductSupplyRecordDto> ProductSupplies { get; set; } = null!;

        public DbSet<ProductUtilRecordDto> ProductUtils { get; set; } = null!;

        public DbSet<ReturnRecordDto> Returns { get; set; } = null!;

        public DbSet<SupplierRecordDto> Suppliers { get; set; } = null!;

        public DbSet<SupplyRecordDto> Supplies { get; set; } = null!;

        public DbSet<TcRecordDto> Tcs { get; set; } = null!;

        public DbSet<TtnRecordDto> Ttns { get; set; } = null!;

        public DbSet<UtilizationRecordDto> Utilizations { get; set; } = null!;

        public DbSet<UtilizerRecordDto> Utilizers { get; set; } = null!;
    }
}