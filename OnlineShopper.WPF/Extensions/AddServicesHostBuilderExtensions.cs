using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopper.Data.Services.Manager;
using OnlineShopper.Data.Services.Transactions.Manager;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.Domain.Services.Transactions.Facade;

namespace OnlineShopper.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(
                services =>
                {
                    //services.AddSingleton<IPasswordHasher, PasswordHasher>();
                    //services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<IDataService<Account>, AccountsService>();
                    services.AddSingleton<IAccountsService, AccountsService>();
                    services.AddSingleton<IProductsService, ProductsService>();
                    services.AddSingleton<IBuyProductsService, BuyProductsService>();
                    services.AddSingleton<ISellProductsService, SellProductsService>();
                }
            );

            return host;
        }
    }
}
