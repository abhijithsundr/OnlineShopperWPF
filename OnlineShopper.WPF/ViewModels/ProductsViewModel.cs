using System.Collections.Generic;
using System.Windows.Input;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.WPF.Commands;

namespace OnlineShopper.WPF.ViewModels
{
    internal class ProductsViewModel : ViewModelBase
    {
        private List<Product> _products;
        
        public ICommand LoadProductsCommand { get; }
        
        public ProductsViewModel(IProductsService service)
        {
            LoadProductsCommand = new LoadProductsCommand(this, service);
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
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public static ProductsViewModel LoadProductsViewModel(IProductsService service)
        {
            ProductsViewModel productsViewModel = new ProductsViewModel(service);

            productsViewModel.LoadProductsCommand.Execute(null);

            return productsViewModel;
        }

    }
}
