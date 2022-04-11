using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopper.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopper.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices(
                (context, services) =>
                {
                    Action<DbContextOptionsBuilder> configureDbContext = o =>
                        o.UseInMemoryDatabase("localdb");

                    services.AddDbContext<OnlineShopperDbContext>(configureDbContext);
                    services.AddSingleton<OnlineShopperDbContextFactory>(
                        new OnlineShopperDbContextFactory(configureDbContext)
                    );
                }
            );

            return host;
        }
    }
}
