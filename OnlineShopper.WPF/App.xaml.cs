using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopper.Data;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.AuthenticationServices;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.WPF.HostBuilders;

namespace OnlineShopper.WPF
{
    /// <summary>
    /// Sets up application on startup
    /// </summary>
    sealed partial class App : Application
    {
        // private ServiceProvider serviceProvider;

        // public App()
        // {
        //     ServiceCollection services = new ServiceCollection();
        //     ConfigureServices(services);
        //     serviceProvider = services.BuildServiceProvider();
        // }

        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContext()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddViews();
        }

        // private void ConfigureServices(ServiceCollection services)
        // {
        //     OnlineShopperDbContext contextFactory =
        //         _host.Services.GetRequiredService<OnlineShopperDbContextFactory>();
        //     services.AddDbContext<OnlineShopperDbContext>(
        //         options =>
        //         {
        //             options.UseInMemoryDatabase("localdb");
        //         }
        //     );

        //     services.AddSingleton<MainWindow>();
        // }

        protected async override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            OnlineShopperDbContextFactory contextFactory =
                _host.Services.GetRequiredService<OnlineShopperDbContextFactory>();
            using (OnlineShopperDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.EnsureCreated();
                context.Database.IsInMemory();
            }

            SeedAdminUser();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            Application.Current.MainWindow.WindowState = WindowState.Maximized;

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        private async void SeedAdminUser()
        {
            IAccountsService accountsService =
                _host.Services.GetRequiredService<IAccountsService>();
            IPasswordHasher<User> passwordHasher = _host.Services.GetRequiredService<
                IPasswordHasher<User>
            >();
            AuthenticationService authenticationService = new AuthenticationService(
                accountsService,
                passwordHasher
            );

            await authenticationService.Register(
                "admin@onlineshopper.com",
                "admin",
                "admin",
                "admin"
            );
        }
    }
}
