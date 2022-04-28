using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.WPF.ViewModels;

namespace OnlineShopper.WPF.Commands
{
    internal class AddProductCommand : AsyncCommandBase
    {
        private readonly AdminViewModel _viewModel;
        private readonly IProductsService _service;

        public AddProductCommand(AdminViewModel viewModel, IProductsService service)
        {
            _viewModel = viewModel;
            _service = service;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _service.Create((Product) parameter);
                _viewModel.StatusMessage = "Success";
            }
            catch (Exception ex)
            {
                _viewModel.StatusMessage = ex.Message;
            }
        }
    }
}