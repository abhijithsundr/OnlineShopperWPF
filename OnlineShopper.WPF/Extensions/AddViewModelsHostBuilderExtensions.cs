﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopper.WPF.State.Navigators;
using OnlineShopper.WPF.ViewModels.Factories;
using OnlineShopper.WPF.ViewModels;
using System;
using OnlineShopper.WPF.State.Authenticators;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.Domain.Services.Transactions.Facade;

namespace OnlineShopper.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(
                services =>
                {
                    services.AddTransient(CreateHomeViewModel);
                    services.AddTransient(CreateProductsViewModel);
                    services.AddTransient<ProfileViewModel>();
                    services.AddTransient<AdminViewModel>();
                    //services.AddTransient<AssetSummaryViewModel>();
                    services.AddTransient<MainViewModel>();

                    services.AddSingleton<CreateViewModel<HomeViewModel>>(
                        services => () => services.GetRequiredService<HomeViewModel>()
                    );
                    services.AddSingleton<CreateViewModel<ProductsViewModel>>(
                        services => () => services.GetRequiredService<ProductsViewModel>()
                    );
                    services.AddSingleton<CreateViewModel<ProfileViewModel>>(
                        services => () => services.GetRequiredService<ProfileViewModel>()
                    );
                    services.AddSingleton<CreateViewModel<AdminViewModel>>(
                        services => () => services.GetRequiredService<AdminViewModel>()
                    );
                    services.AddSingleton<CreateViewModel<LoginViewModel>>(
                        services => () => CreateLoginViewModel(services)
                    );
                    services.AddSingleton<CreateViewModel<RegisterViewModel>>(
                        services => () => CreateRegisterViewModel(services)
                    );

                    services.AddSingleton<
                        IOnlineShopperViewModelFactory,
                        OnlineShopperViewModelFactory
                    >();

                    services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
                }
            );

            return host;
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel();
        }

        private static ProductsViewModel CreateProductsViewModel(IServiceProvider services)
        {
            return ProductsViewModel.LoadProductsViewModel(
                services.GetRequiredService<IProductsService>(),
                services.GetRequiredService<IBuyProductsService>(),
                services.GetRequiredService<ISellProductsService>(),
                services.GetRequiredService<IAuthenticator>()
            );
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>()
            );
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
            );
        }
    }
}
