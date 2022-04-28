using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Services.Transactions.Facade;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.Commands
{
    internal class BuyProductCommand : AsyncCommandBase
    {
        private readonly ProductsViewModel _productsViewModel;
        private readonly IBuyProductsService _service;
        private readonly int _accountId;

        public BuyProductCommand(
            ProductsViewModel productsViewModel,
            IBuyProductsService service,
            int accountId
        )
        {
            _productsViewModel = productsViewModel;
            _service = service;
            _accountId = accountId;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            //parameter should have productId
            try
            {
                await _service.BuyProduct(_accountId, (int)parameter, true);
                _productsViewModel.StatusMessage = "Success";
            }
            catch (Exception ex)
            {
                _productsViewModel.StatusMessage = ex.Message;
            }
        }
    }
}
