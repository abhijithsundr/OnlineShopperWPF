using System.Collections.Generic;
using System.Windows.Input;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.Domain.Services.Transactions.Facade;
using OnlineShopper.WPF.Commands;
using OnlineShopper.WPF.State.Authenticators;

namespace OnlineShopper.WPF.ViewModels
{
    internal class ProductsViewModel : ViewModelBase
    {
        private List<Product> _products;

        public ICommand LoadProductsCommand { get; }

        public ICommand BuyProductCommand { get; }
        public ICommand SellProductForCashCommand { get; }
        public ICommand SellProductForVoucherCommand { get; }

        public ProductsViewModel(
            IProductsService service,
            IBuyProductsService buyProductsService,
            ISellProductsService sellProductsService,
            IAuthenticator authenticator
        )
        {
            LoadProductsCommand = new LoadProductsCommand(this, service);
            BuyProductCommand = new BuyProductCommand(
                this,
                buyProductsService,
                authenticator.CurrentAccount.Id
            );
            SellProductForCashCommand = new SellProductForCashCommand(
                this,
                sellProductsService,
                authenticator.CurrentAccount.Id
            );
            SellProductForVoucherCommand = new SellProductForVoucherCommand(
                this,
                sellProductsService,
                authenticator.CurrentAccount.Id
            );
        }

        public List<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public static ProductsViewModel LoadProductsViewModel(
            IProductsService service,
            IBuyProductsService buyProductsService,
            ISellProductsService sellProductsService,
            IAuthenticator authenticator
        )
        {
            ProductsViewModel productsViewModel = new ProductsViewModel(
                service,
                buyProductsService,
                sellProductsService,
                authenticator
            );

            productsViewModel.LoadProductsCommand.Execute(null);

            return productsViewModel;
        }
    }
}
