using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.WPF.Commands;

namespace OnlineShopper.WPF.ViewModels
{
    internal class AdminViewModel : ViewModelBase
    {
        public ICommand AddProductCommand { get; }

        public AdminViewModel(IProductsService service)
        {
            AddProductCommand = new AddProductCommand(this, service);
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
    }
}
