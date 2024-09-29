using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneStore.Domain.Models;
using PhoneStore.Persistence.Seeders;

namespace PhoneStore.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateTimeConverter = new ValueConverter<DateTime, DateTime>
                (
                v => v.Kind == DateTimeKind.Unspecified
                     ? DateTime.SpecifyKind(v, DateTimeKind.Utc)
                     : v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                 );
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(dateTimeConverter);
                }
            }
            ProvinceSeeder.SeedProvinces(modelBuilder);
        }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<ExtraExpenses> ExtraExpenses { get; set; }
        public DbSet<CustomersPayment> CustomersPayments { get; set; }
        public DbSet<SuppliersPayment> SuppliersPayments { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SupplierLoans> SupplierLoans { get; set; }
        public DbSet<CustomerLoans> CustomerLoans { get; set; }

    }
}
