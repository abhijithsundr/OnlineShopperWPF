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
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("localdb");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
