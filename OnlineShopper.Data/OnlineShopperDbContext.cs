using Microsoft.EntityFrameworkCore;
using OnlineShopper.Domain.Models;

namespace OnlineShopper.Data
{
    public class OnlineShopperDbContext : DbContext
    {
        public OnlineShopperDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            modelBuilder.Entity<Account>().HasOne(x => x.AccountHolder);

            SeedProducts(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("localdb");

            base.OnConfiguring(optionsBuilder);
        }

        private void SeedProducts(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasData(
                    new[]
                    {
                        new Product()
                        {
                            Id = 1,
                            ProductName = "Apple Macbook Air",
                            ProductDescription = "Apple Macbook Air 14 inches",
                            Category = Category.Laptops,
                            BuyPrice = 1400,
                            SellPrice = 1200,
                            VoucherPrice = 1250,
                            Inventory = 100
                        },
                        new Product()
                        {
                            Id = 2,
                            ProductName = "Asus Zephyrus",
                            ProductDescription = "Asus Zephryus X10983",
                            Category = Category.Laptops,
                            BuyPrice = 1700,
                            SellPrice = 1400,
                            VoucherPrice = 1550,
                            Inventory = 100
                        },
                        new Product()
                        {
                            Id = 3,
                            ProductName = "Samsung Galaxy Fold",
                            ProductDescription = "Samsung Galaxy Fold X832A",
                            Category = Category.Mobiles,
                            BuyPrice = 1200,
                            SellPrice = 900,
                            VoucherPrice = 1050,
                            Inventory = 100
                        },
                    }
                );
        }
    }
}
