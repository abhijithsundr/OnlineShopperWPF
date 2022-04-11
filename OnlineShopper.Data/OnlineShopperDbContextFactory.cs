using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineShopper.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopper.Data
{
    public class OnlineShopperDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public OnlineShopperDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public OnlineShopperDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<OnlineShopperDbContext> options =
                new DbContextOptionsBuilder<OnlineShopperDbContext>();

            _configureDbContext(options);

            return new OnlineShopperDbContext(options.Options);
        }
    }
}
