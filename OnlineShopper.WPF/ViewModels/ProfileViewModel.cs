using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using OnlineShopper.Domain.Models;
using OnlineShopper.Domain.Services.Facade;
using OnlineShopper.WPF.State.Authenticators;

namespace OnlineShopper.WPF.ViewModels
{
    internal class ProfileViewModel : ViewModelBase 
    { 
        private Account _account;
        private IAccountsService _service;
        
        public ProfileViewModel(IAuthenticator authenticator, IAccountsService service)
        {
            _account = authenticator.CurrentAccount;
            _service = service;
        }

        public Account Account
        {
            get { return _account; }
            set
            {
                _account = value;
                OnPropertyChanged(nameof(Account));
            }
        }

        public async Task AddMoney(double amount)
        {
            await _service.CreditCashBalance(Account.Id, amount);
            OnPropertyChanged(nameof(Account));
        }
    }
}
