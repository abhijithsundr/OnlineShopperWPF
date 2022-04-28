using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Services.Transactions.Facade;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.Commands
{
    internal class SellProductForVoucherCommand : AsyncCommandBase
    {
        private readonly ProductsViewModel _viewModel;
        private readonly ISellProductsService _service;
        private readonly int _accountId;

        public SellProductForVoucherCommand(
            ProductsViewModel viewModel,
            ISellProductsService service,
            int accountId
        )
        {
            _viewModel = viewModel;
            _service = service;
            _accountId = accountId;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            //Parameter should have the product id
            try
            {
                await _service.SellProduct(_accountId, (int) parameter, false);
                _viewModel.StatusMessage = "Success";
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}