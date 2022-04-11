using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopper.Data;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            OnlineShopperDbContextFactory contextFactory =
                _host.Services.GetRequiredService<OnlineShopperDbContextFactory>();
            using (OnlineShopperDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.EnsureCreated();
                context.Database.IsInMemory();
            }

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
