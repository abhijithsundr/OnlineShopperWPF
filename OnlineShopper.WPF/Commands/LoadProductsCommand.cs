using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.WPF.Commands;
using OnlineShopper.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShopper.WPF.Commands
{
    internal class LoadProductsCommand : AsyncCommandBase
    {
        private readonly ProductsViewModel _productsViewModel;
        private readonly IProductsService _productsService;

        public LoadProductsCommand(ProductsViewModel productsViewModel, IProductsService productsService)
        {
            _productsViewModel = productsViewModel;
            _productsService = productsService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _productsViewModel.IsLoading = true;

            var products = await _productsService.GetAll(parameter as Expression<Func<Product,bool>>);
            var list = new List<Product>();
            await foreach(var prod in products)
            {
                list.Add(prod);
            }
            _productsViewModel.Products = list;

            _productsViewModel.IsLoading = false;
        }
    }
}
